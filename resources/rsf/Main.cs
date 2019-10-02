using System;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using rsf.Database;

namespace rsf
{
    public class Main : Script
    {
        public static JObject Config = JObject.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/conf.json"));
        public static readonly Random Zufall = new Random();
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
            using var ctx = new DefaultDbContext();
            NAPI.Util.ConsoleOutput($"Charaktere: {NAPI.Util.ToJson(ctx.Characters.Where(t => t.AccountModelId == 3))}");
            // NAPI.Server.SetCommandErrorMessage("[~r~SERVER:~w~] Dieser Command Existiert nicht!");
        }
    }
}