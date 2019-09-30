using System;
using GTANetworkAPI;

namespace rsf
{
    public class Main : Script
    {
        public Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            //Console.WriteLine("(~~~~~~~~~~~~~~~~~~~~~)");
            //Console.WriteLine("( Script by AbsturzPowa 2019)");
            //Console.WriteLine("( Version Dev0.4.1");
            //Console.WriteLine("(~~~~~~~~~~~~~~~~~~~~~)");
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

        [Command("test")]
        public void CMD_Test(Client client)
        {
            client.SendChatMessage("Hello there!");
        }
    }
}