using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rsf.Managers
{
    public class DimensionManager : Script
    {
        private static Dictionary<uint, Client> DimensionsInUse = new Dictionary<uint, Client>();

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
        {
            NAPI.Util.ConsoleOutput("1");
            if (DimensionsInUse.ContainsValue(player))
                DismissPrivateDimension(player);
            NAPI.Util.ConsoleOutput("2");
        }

        public static uint RequestPrivateDimension(Client requester)
        {
            uint firstUnusedDim = 00;

            lock (DimensionsInUse)
            {
                while (DimensionsInUse.ContainsKey(--firstUnusedDim))
                {
                }

                DimensionsInUse.Add(firstUnusedDim, requester);
            }
            return firstUnusedDim;
        }

        public static void DismissPrivateDimension(Client requester)
        {
            lock (DimensionsInUse)
            {
                for (int i = DimensionsInUse.Count - 1; i >= 0; i--)
                {
                    if (DimensionsInUse.ElementAt(i).Value == requester)
                        DimensionsInUse.Remove(DimensionsInUse.ElementAt(i).Key);
                }
            }
        }
    }
}
