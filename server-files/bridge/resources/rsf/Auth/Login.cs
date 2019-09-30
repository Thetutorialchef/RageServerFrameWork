using System;
using System.Linq;
using BCrypt;
using GTANetworkAPI;
using rsf.Database;
using rsf.Managers;
using rsf.Models;

namespace rsf.Auth
{
    internal class Login : Script
    {
        [ServerEvent(Event.PlayerDisconnected)]
        public void Disconnect(Client player, DisconnectionType type, string reason)
        {
            NAPI.Util.ConsoleOutput($"{player.Name} hat den Server verlassen.");
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Client player)
        {
            NAPI.Util.ConsoleOutput($"{player.Name} ist gejoint.");
            using (var ctx = new DefaultDbContext())
            {
                player.TriggerEvent("ShowLoginForm", ctx.Accounts.Count(t => string.Equals(t.SocialClubName, player.SocialClubName, StringComparison.CurrentCultureIgnoreCase)) == 1);
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
                player.TriggerEvent("AuthError", "Der Benutzername oder das Passwort ist falsch.");
                return;
            }

            user.Player = player;
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
            if (ctx.Accounts.Count(t => string.Equals(t.SocialClubName, player.SocialClubName, StringComparison.CurrentCultureIgnoreCase)) != 0)
            {
                player.TriggerEvent("AuthError", "Dieser Benutzername existiert bereits.");
                return;
            }

            var ip = player.Address.Split('.');
            var user = new AccountModel
            {
                Password = BCryptHelper.HashPassword((string)arguments[0], BCryptHelper.GenerateSalt()),
                Email = (string)arguments[1],
                SocialClubName = player.SocialClubName,
                Ip = $"{ip[0]}.{ip[1]}.XXX.XXX",
                Player = player
            };
            ctx.Accounts.Add(user);
            player.SetData("User", user);
            player.TriggerEvent("ShowCharacterSelection");
            ctx.SaveChanges();
        }

        #endregion
    }
}