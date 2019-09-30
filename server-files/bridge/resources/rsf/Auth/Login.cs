using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BCrypt;
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
            NAPI.Util.ConsoleOutput($"{player.Name} ist gejoint.");
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
            using var ctx = new DefaultDbContext();
            var user = ctx.Accounts.FirstOrDefault(up => string.Equals(up.SocialClubName, player.SocialClubName, StringComparison.CurrentCultureIgnoreCase));
            if (user == null || !BCryptHelper.CheckPassword((string)arguments[0], user.Password))
            {
                player.TriggerEvent("LoginError", "LoginDaten Incorrect.");
                return;
            }

            user.SocialClubName = player.SocialClubName;
            player.SetData("User", user);
            player.TriggerEvent("ShowCharacterSelection");
        }

        #endregion

        #region Register

        [RemoteEvent("RegisterAttempt")]
        public void RegisterAttempt(Client player, object[] arguments)
        {
            using var ctx = new DefaultDbContext();
            if (ctx.Accounts.Count(t => string.Equals(t.SocialClubName, player.SocialClubName, StringComparison.CurrentCultureIgnoreCase)) == 0)
            {
                var user = new AccountModel
                {
                    Password = BCrypt.BCryptHelper.HashPassword((string)arguments[0], BCryptHelper.GenerateSalt()),
                    Email = (string)arguments[1],
                    SocialClubName = player.SocialClubName,
                    Ip = player.Address
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

        #endregion
    }
}