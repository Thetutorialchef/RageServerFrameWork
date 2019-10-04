using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using rsf;
using Vehicle = GTANetworkAPI.Vehicle;

namespace Server.resources.rsf.Commands
{
    public class Admin:Script
    {
        public static List<Vehicle> AdminVehicle = new List<Vehicle>();

        [Command("c")]
        public void Setclothes(Client client, int slot, int drawable, byte color = 1, byte highlight = 0)
        {
            client.SetClothes(slot, drawable, 0);
            //NAPI.Player.SetPlayerClothes(client, 2, drawable, 0);
            NAPI.Player.SetPlayerHairColor(client, color, highlight);
        }

        [Command("haar")]
        public void Haar(Client player, int style)
        {
            player.SetClothes(2, style, style);
        }

        [Command("veh", Alias = "v")]
        public void VehCommand(Client player, VehicleHash name, int farbe1 = -1, int farbe2 = -1)
        {
            if (farbe1 < 0) farbe1 = Main.Zufall.Next(0, 159);
            if (farbe2 < 0) farbe2 = Main.Zufall.Next(0, 159);
            var veh = NAPI.Vehicle.CreateVehicle(name, player.Position, player.Rotation, farbe1, farbe2);
            veh.Dimension = player.Dimension;
            AdminVehicle.Add(veh);
            player.SetIntoVehicle(veh, -1);
            player.SendNotification("Fahrzeug gespawnt.");
        }

        [Command("avdel")]
        public void AvDel(Client player)
        {
            foreach (var veh in AdminVehicle.Where(veh => veh.Exists))
            {
                veh.Delete();
            }
            AdminVehicle.RemoveAll(t => !t.Exists);
            player.SendNotification("Fahrzeuge entfernt.");
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
