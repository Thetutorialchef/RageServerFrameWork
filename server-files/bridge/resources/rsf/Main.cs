using GTANetworkAPI;
using System;

namespace rsf
{
    public class Main : Script
    {
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





        public Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;

        }

        [Command("test")]
       public void CMD_Test(Client client)
       {
         client.SendChatMessage("Hello there!");
       }

    }
}
