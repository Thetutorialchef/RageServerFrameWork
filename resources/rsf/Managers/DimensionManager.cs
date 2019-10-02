using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;

namespace rsf.Managers
{
    public class DimensionManager : Script
    {
        private static readonly Dictionary<uint, Client> DimensionsInUse = new Dictionary<uint, Client>();

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Client player, DisconnectionType type, string reason)
        {
            //NAPI.Util.ConsoleOutput("1");
            lock (DimensionsInUse)
            {
                if (DimensionsInUse.ContainsValue(player))
                    DismissPrivateDimension(player);
            }
            //NAPI.Util.ConsoleOutput("2");
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
                for (var i = DimensionsInUse.Count - 1; i >= 0; i--)
                    if (DimensionsInUse.ElementAt(i).Value == requester)
                        DimensionsInUse.Remove(DimensionsInUse.ElementAt(i).Key);
            }
        }
    }
}