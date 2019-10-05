using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using rsf;
using rsf.Database;
using rsf.Models;
using Server.resources.rsf.Models;
using Vehicle = GTANetworkAPI.Vehicle;

namespace Server.resources.rsf.Commands
{
    public class Admin:Script
    {
        public static List<Fahrzeug> AdminVehicle = new List<Fahrzeug>();

        [Command]
        public void speichern(Client player)
        {
            if(!player.HasData("SetClothes-Geschlecht"))
            {
                player.SendChatMessage("Bitte zuerst /setclothes [Texture]");
                return;
            }
            if (!player.HasData("SetClothes-UnterhemdDrawable"))
            {
                player.SendChatMessage("Bitte zuerst /unterhemd [ID]");
                return;
            }
            if(!player.HasData("SetClothes-TorsoDrawable"))
            {
                player.SendChatMessage("Bitte zuerst /torso [ID]");
                return;
            }
            using var ctx = new DefaultDbContext();
            var clothes = new Clothes
            {
                Geschlecht = player.GetData("SetClothes-Geschlecht"),
                Drawable = player.GetData("SetClothes-Drawable"),
                Texture = player.GetData("SetClothes-Texture"),
                TorsoDrawable = player.GetData("SetClothes-TorsoDrawable"),
                TorsoTexture = player.GetData("SetClothes-TorsoTexture"),
                UnterhemdDrawable = player.GetData("SetClothes-UnterhemdDrawable"),
                UnterhemdTexture = player.GetData("SetClothes-UnterhemdTexture")
            };

            player.SetData("SetClothes-Geschlecht", null);
            player.SetData("SetClothes-Drawable", null);
            player.SetData("SetClothes-Texture", null);
            player.SetData("SetClothes-TorsoDrawable", null);
            player.SetData("SetClothes-TorsoTexture", null);
            player.SetData("SetClothes-UnterhemdDrawable", null);
            player.SetData("SetClothes-UnterhemdTexture", null);

            player.ResetData("SetClothes-Geschlecht");
            player.ResetData("SetClothes-TorsoDrawable");
            player.ResetData("SetClothes-UnterhemdDrawable");

            ctx.Clothes.Add(clothes);
            ctx.SaveChanges();
            player.SendChatMessage($"Kleidung gespeichert. Id: {clothes.Id}");
        }

        [Command]
        public void Unterhemd(Client player, int unterhemd)
        {
            AccountModel acc = player.GetData("User");
            if (acc.Character.Geschlecht && unterhemd > 186) // Frau
            {
                player.SendChatMessage("Maximal 186 Unterhemden für Frauen.");
                return;
            }
            if (!acc.Character.Geschlecht && unterhemd > 150)
            {
                player.SendChatMessage("Maximal 150 Unterhemden für Männer.");
                return;
            }
            player.SetClothes(8, unterhemd, 0);
            player.SetData("SetClothes-UnterhemdDrawable", unterhemd);
            player.SetData("SetClothes-UnterhemdTexture", 0);
        }

        [Command]
        public void SetClothes(Client player, int texture)
        {
            NAPI.Util.ConsoleOutput($"1");
            if (texture > 10)
            {
                player.SendChatMessage("Texture ist zu hoch..");
                return;
            }

            NAPI.Util.ConsoleOutput($"2");
            AccountModel acc = player.GetData("User");

            var index = acc.Character.Geschlecht ? 324 : 313;
            NAPI.Util.ConsoleOutput($"3");

            using var ctx = new DefaultDbContext();
            NAPI.Util.ConsoleOutput($"4");

            if (ctx.Clothes.FirstOrDefault(t => t.Drawable == index && t.Geschlecht == acc.Character.Geschlecht && t.Texture == texture) != null)
            {
                NAPI.Util.ConsoleOutput($"5");
                player.SendChatMessage("Diese Textur existiert bereits.");
                return;
            }

            var drawable = ctx.Clothes.Count(t => t.Geschlecht == acc.Character.Geschlecht && t.Texture == texture) == 0 ? 1 : (int)ctx.Clothes.Where(t => t.Geschlecht == acc.Character.Geschlecht && t.Texture == texture)?.Max(t => t.Drawable) + 1;
            NAPI.Util.ConsoleOutput($"6");
            if (drawable >= index)
            {
                NAPI.Util.ConsoleOutput($"7");
                player.SendChatMessage("Bitte eine andere Textur eingeben.");
                return;
            }
            NAPI.Util.ConsoleOutput($"8 - {drawable}");

            var torso = Main.BestTorsoFemale[drawable.ToString()][texture.ToString()];

            player.SetData("SetClothes-Geschlecht", acc.Character.Geschlecht);
            player.SetData("SetClothes-Drawable", drawable);
            player.SetData("SetClothes-Texture", texture);
            player.SetClothes(11, drawable, texture);

            player.SendChatMessage("Nun /unterhemd [ID] /torso [ID]");
            player.SendChatMessage("Wenn es passt: /speichern, wenn nicht /setclothes [Texture-ID]");


            if ((int) torso["BestTorsoDrawable"] == -1) return;

            player.SetClothes(3, (int)torso["BestTorsoDrawable"], (int)torso["BestTorsoTexture"]);

            player.SetData("SetClothes-TorsoDrawable", (int)torso["BestTorsoDrawable"]);
            player.SetData("SetClothes-TorsoTexture", (int)torso["BestTorsoTexture"]);
        }

        [Command]
        public void Torso(Client player, int id)
        {
            AccountModel acc = player.GetData("User");
            if (id > 15)
            {
                player.SendChatMessage("Maximal 15 Körper.");
                return;
            }
            player.SetClothes(3, id, 0);
            player.SetData("SetClothes-TorsoDrawable", id);
            player.SetData("SetClothes-TorsoTexture", 0);
        }

        [Command("veh", Alias = "v")]
        public void VehCommand(Client player, string name, int farbe1 = -1, int farbe2 = -1)
        {
            if (farbe1 < 0) farbe1 = Main.Zufall.Next(0, 159);
            if (farbe2 < 0) farbe2 = Main.Zufall.Next(0, 159);

            var fahrzeug = new Fahrzeug();
            fahrzeug.PosX = player.Position.X;
            fahrzeug.PosY = player.Position.Y;
            fahrzeug.PosZ = player.Position.Z;
            fahrzeug.RotX = player.Rotation.X;
            fahrzeug.RotY = player.Rotation.Y;
            fahrzeug.RotZ = player.Rotation.Z;
            fahrzeug.Dimension = player.Dimension;
            fahrzeug.PrimaryColor = farbe1;
            fahrzeug.SecondaryColor = farbe2;
            fahrzeug.Name = name;
            fahrzeug.Spawn();
            AdminVehicle.Add(fahrzeug);
            player.SetIntoVehicle(fahrzeug.Vehicle, -1);
            player.SendNotification("Fahrzeug gespawnt.");
        }

        [Command("avdel")]
        public void AvDel(Client player)
        {
            foreach (var veh in AdminVehicle.Where(veh => veh.Vehicle.Exists))
            {
                veh.Vehicle.Delete();
            }
            AdminVehicle.RemoveAll(t => !t.Vehicle.Exists);
            player.SendNotification("Fahrzeuge entfernt.");
        }

        [Command]
        public void Skin(Client player, PedHash skin)
        {
            //-1950698411
            player.SetSkin(skin);
        }

        [Command(GreedyArg = true)]
        public void Save(Client player, string kommentar = "")
        {
            var text =
                $"NAPI.Ped.CreatePed({player.Model}, new Vector3({player.Position.X.Cc()}, {player.Position.Y.Cc()}, {player.Position.Z.Cc()}), (float){player.Rotation.Z.Cc()}, {player.Dimension}); // {kommentar}";
            if (player.IsInVehicle)
                text =
                    $"NAPI.Vehicle.CreateVehicle({player.Vehicle.Model}, new Vector3({player.Vehicle.Position.X.Cc()}, {player.Vehicle.Position.Y.Cc()}, {player.Vehicle.Position.Z.Cc()}), new Vector3({player.Vehicle.Rotation.X.Cc()}, {player.Vehicle.Rotation.Y.Cc()}, {player.Vehicle.Rotation.Z.Cc()}), {player.Vehicle.PrimaryColor}, {player.Vehicle.SecondaryColor}, \"{player.Vehicle.NumberPlate}\", 255, false, false, {player.Vehicle.Dimension}) // {kommentar}";
            File.AppendAllText($"{Main.CurrDirectory}savedpositions.txt", $"{text}{Environment.NewLine}");
            player.SendNotification("Position gespeichert.");
        }
    }
}
