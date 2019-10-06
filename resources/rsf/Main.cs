using System;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using rsf.Database;
using rsf.Models;
using Server.resources.rsf.Models;

namespace rsf
{
    public class Main : Script
    {
        public static readonly Random Zufall = new Random();
        public static readonly string CurrDirectory = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}bridge{Path.DirectorySeparatorChar}resources{Path.DirectorySeparatorChar}rsf{Path.DirectorySeparatorChar}";
        public static JObject Config = JObject.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/conf.json"));
        public static JObject BestTorsoMale = JObject.Parse(File.ReadAllText($"{CurrDirectory}/json/besttorso_male.json"));
        public static JObject BestTorsoFemale = JObject.Parse(File.ReadAllText($"{CurrDirectory}/json/besttorso_female.json"));

        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            var a = Zufall.Next(0, 313);
            NAPI.Util.ConsoleOutput($"a: {a}");
            NAPI.Util.ConsoleOutput($"BestTorsoTexture: {BestTorsoMale[a.ToString()]["0"]["BestTorsoTexture"]}");
            NAPI.Util.ConsoleOutput($"BestTorsoDrawable: {BestTorsoMale[a.ToString()]["0"]["BestTorsoDrawable"]}");
            NAPI.Util.ConsoleOutput($"Streamrate: {(int)Config.GetValue("stream-distance")}"); // Wichtig für die Synchronisation von Sachen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("         RageMP Server Framework Version [0.0.1]      ");
            Console.WriteLine("------------------------------------------------------");

            NAPI.Server.SetAutoRespawnAfterDeath(false);
            NAPI.Server.SetGlobalServerChat(false);
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetAutoRespawnAfterDeath(false);

            using var ctx = new DefaultDbContext();
            foreach (var frak in ctx.Fraktionen)
            {
                for (var i = 0; i < frak.MaxRaenge; i++)
                {
                    if (ctx.Fraktionsraenge.FirstOrDefault(t => t.FraktionenModelId == frak.Id && t.Rang == i + 1) != null) continue;
                    var rang = new FraktionsraengeModel
                    {
                        FraktionenModelId = frak.Id, Rang = (byte) (i + 1), Name = $"Rang {i + 1}"
                    };
                    ctx.Fraktionsraenge.Add(rang);
                }
            }
            ctx.SaveChanges();

            foreach (var fahrzeug in ctx.Fraktionsfahrzeug)
            {
                fahrzeug.Spawn();
            }

            // NAPI.Server.SetCommandErrorMessage("[~r~SERVER:~w~] Dieser Command Existiert nicht!");
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Client player, Client killer, uint reason)
        {
            if (!player.HasData("User")) return;
            player.SendChatMessage("Tot.");
            NAPI.Task.Run(() =>
            {
                AccountModel acc = player.GetData("User");
                NAPI.Player.SpawnPlayer(player, new Vector3(343.114, -1398.1271, 32.509262), 44f);
                acc.Character.PosX = player.Position.X;
                acc.Character.PosY = player.Position.Y;
                acc.Character.PosZ = player.Position.Z;

                acc.Character.RotX = player.Rotation.X;
                acc.Character.RotY = player.Rotation.Y;
                acc.Character.RotZ = player.Rotation.Z;

            }, 1000);
        }

        [RemoteEvent("OnSwitchBlinker")]
        public void OnSwitchBlinker(Client player, bool blinkerL)
        {
            if (!player.IsInVehicle || player.VehicleSeat != -1 || !player.Vehicle.HasData("Fahrzeug")) return;

            Fahrzeug fahrzeug = player.Vehicle.GetData("Fahrzeug");
            if (blinkerL)
                fahrzeug.BlinkerL = !fahrzeug.BlinkerL;
            else
                fahrzeug.BlinkerR = !fahrzeug.BlinkerR;
            foreach (var player2 in NAPI.Player.GetPlayersInRadiusOfPlayer((int)Config.GetValue("stream-distance"), player))
                player2.TriggerEvent("OnPlayerBlinker", fahrzeug.Vehicle, blinkerL, blinkerL ? fahrzeug.BlinkerL : fahrzeug.BlinkerR);
            fahrzeug.Vehicle.SetSharedData("BlinkerL", fahrzeug.BlinkerL);
            fahrzeug.Vehicle.SetSharedData("BlinkerR", fahrzeug.BlinkerR);

        }
    }
}