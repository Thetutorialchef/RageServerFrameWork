using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using GTANetworkAPI;
using rsf.Database;
using rsf.Managers;
using rsf.Models;

namespace rsf.Auth
{
    internal class Login : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Client player)
        {
            using (var ctx = new DefaultDbContext())
            {
                var user = ctx.Accounts.FirstOrDefault(x => x.SocialClubName == player.SocialClubName);
                if (user != null)
                {
                    user.Ip = player.Address;
                    player.SetData("User", user);
                    player.TriggerEvent("ShowCharacterSelection");
                    ctx.SaveChanges();
                }
                else
                {
                    player.TriggerEvent("ShowLoginForm", NAPI.Util.ToJson(new Dictionary<string, string>
                    {
                        {"name", player.Name},
                        {"socialClub", player.SocialClubName}
                    }));
                }
            }

            player.Dimension = DimensionManager.RequestPrivateDimension(player);
        }

        #region Login

        [RemoteEvent("LoginAttempt")]
        public void LoginAttempt(Client player, object[] arguments)
        {
            var username = (string) arguments[0];
            var password = Encrypt((string) arguments[1]);

            using (var ctx = new DefaultDbContext())
            {
                var user = ctx.Accounts.FirstOrDefault(up => up.Username == username && up.Password == password);
                if (user != null)
                {
                    user.SocialClubName = player.SocialClubName;
                    player.SetData("User", user);
                    player.TriggerEvent("ShowCharacterSelection");
                }
                else
                {
                    player.TriggerEvent("LoginError", "LoginDaten Incorrect.");
                }
            }
        }

        #endregion

        #region Register

        [RemoteEvent("RegisterAttempt")]
        public void RegisterAttempt(Client player, object[] arguments)
        {
            var username = (string) arguments[0];
            var password = Encrypt((string) arguments[1]);
            var emailadd = (string) arguments[2];

            using (var ctx = new DefaultDbContext())
            {
                var user = ctx.Accounts.FirstOrDefault(x => x.Username == username);
                if (user == null)
                {
                    user = new AccountModel
                    {
                        Username = username, Password = password, Email = emailadd,
                        SocialClubName = player.SocialClubName, Ip = player.Address
                    };
                    ctx.Accounts.Add(user);
                    player.SetData("User", user);
                    player.TriggerEvent("ShowCharacterSelection");

                    ctx.SaveChanges();
                }
                else
                {
                    player.TriggerEvent("LoginError", "LoginDaten falsch");
                }
            }
        }

        #endregion


        public static string Encrypt(string value)
        {
            using (var hash = SHA256.Create())
            {
                return string.Concat(
                    hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString("x2")));
            }
        }
    }
}