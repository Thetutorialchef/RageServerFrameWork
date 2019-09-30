using System;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json.Linq;

namespace rsf
{
    public class Main : Script
    {
        public static JObject Config = JObject.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/conf.json"));
        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            NAPI.Util.ConsoleOutput($"Streamrate: {(int)Config.GetValue("stream-distance")}"); // Wichtig für die Synchronisation von Sachen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("         RageMP Server Framework Version [0.0.1]      ");
            Console.WriteLine("------------------------------------------------------");

            NAPI.Server.SetAutoRespawnAfterDeath(false);
            NAPI.Server.SetGlobalServerChat(false);
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetAutoRespawnAfterDeath(false);

            //  NAPI.Server.SetCommandErrorMessage("[~r~SERVER:~w~] Dieser Command Existiert nicht!");
        }
    }
}