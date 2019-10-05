using System;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using rsf.Models;

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
    }
}