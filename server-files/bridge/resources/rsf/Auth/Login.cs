using GTANetworkAPI;
using rsf.Database;
using rsf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace rsf.Auth
{
    class Login : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Client player)
        {

            using (var ctx = new DefaultDbContext())
            {
                var user = ctx.Accounts.FirstOrDefault(x => x.SocialClubName == player.SocialClubName);
                NAPI.Util.ConsoleOutput($"a {NAPI.Util.ToJson(user)}");
                if (user != null)
                {
                    user.IP = player.Address;
                    NAPI.Data.SetEntityData(player, "User", user);
                    NAPI.ClientEvent.TriggerClientEvent(player, "ShowCharacterSelection");

                    ctx.SaveChanges();

                }
                else
                {
                    Dictionary<string, string> pData = new Dictionary<string, string>()
                            {
                                {"name", player.Name },
                                {"socialClub", player.SocialClubName }
                            };
                    player.TriggerEvent("ShowLoginForm", NAPI.Util.ToJson(pData));
                  //  NAPI.ClientEvent.TriggerClientEvent(player, "ShowLoginForm", NAPI.Util.ToJson(pData));
                }


            }
            uint dimension = Managers.DimensionManager.RequestPrivateDimension(player);
            NAPI.Entity.SetEntityDimension(player, dimension);
        }

        #region Login
        [RemoteEvent("LoginAttempt")]
        public void LoginAttempt(Client player, object[] arguments)
        {
            string username = (string)arguments[0];
            string password = Encrypt((string)arguments[1]);

            using (var ctx = new DefaultDbContext())
            {
                var user = ctx.Accounts.FirstOrDefault(up => up.Username == username && up.Password == password);
                if (user != null)
                {
                    user.SocialClubName = player.SocialClubName;
                    NAPI.Data.SetEntityData(player, "User", user);
                    NAPI.ClientEvent.TriggerClientEvent(player, "ShowCharacterSelection");
                }
                else
                {
                    NAPI.ClientEvent.TriggerClientEvent(player, "LoginError", "LoginDaten Incorrect.");
                }
            }
        }
        #endregion

        #region Register

        [RemoteEvent("RegisterAttempt")]
        public void RegisterAttempt(Client player, object[] arguments)
        {
            string username = (string)arguments[0];
            string password = Encrypt((string)arguments[1]);
            string emailadd = (string)arguments[2];

            using (var ctx = new DefaultDbContext())
            {
                var user = ctx.Accounts.FirstOrDefault(x => x.Username == username);
                if (user == null)
                {
                    user = new AccountModel { Username = username, Password = password, Email = emailadd, SocialClubName = player.SocialClubName, IP = player.Address };
                    ctx.Accounts.Add(user);

                    NAPI.Data.SetEntityData(player, "User", user);
                    NAPI.ClientEvent.TriggerClientEvent(player, "ShowCharacterSelection");

                    ctx.SaveChanges();
                }
                else
                {
                    NAPI.ClientEvent.TriggerClientEvent(player, "LoginError", "LoginDaten falsch");
                }
            }
        }
        #endregion


        public static String Encrypt(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString("x2")));
            }
        }

    }
}
        