using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;
using rsf.Database;
using rsf.Models;

namespace rsf.Auth
{
    public class Creator : Script
    {
        [RemoteEvent("OnFillCharacters")]
        public void OnFillCharacters(Client player)
        {
            AccountModel acc = player.GetData("User");
            using var ctx = new DefaultDbContext();
            player.TriggerEvent("executeBrowser", $"FillCharaktere({NAPI.Util.ToJson(ctx.Characters.Where(t => t.AccountModelId == acc.Id).Select(t => new { t.Vorname, t.Nachname, t.Id }))})");
            
        }
        [RemoteEvent("CreateCharakter")]
        public void CreateCharakter(Client player, string parameter)
        {
            var errors = new List<string>();
            AccountModel acc = player.GetData("User");
            using var ctx = new DefaultDbContext();
            if (ctx.Characters.Count(t=>t.AccountModelId == acc.Id) >= acc.MaxCharacters)
            {
                player.TriggerEvent("executeBrowser", "HandleError(3)");
                return;
            }
            var serializer = new JsonSerializerSettings {DateFormatString = "yyyy-MM-dd"};
            serializer.Error += (sender, args) =>
            {
                errors.Add(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            };
            var a = JsonConvert.DeserializeObject<CharacterModel>(parameter, serializer);
            if (errors.Count() != 0)
            {
                player.TriggerEvent("executeBrowser", "HandleError(1)");
                return;
            }
            if(ctx.Characters.Count(t=>string.Equals(t.Vorname, a.Vorname, StringComparison.CurrentCultureIgnoreCase) && string.Equals(t.Nachname, a.Nachname, StringComparison.CurrentCultureIgnoreCase)) != 0)
            {
                player.TriggerEvent("executeBrowser", "HandleError(2)");
                return;
            }
            a.AccountModelId = acc.Id;
            ctx.Characters.Add(a);
            ctx.SaveChanges();
            player.TriggerEvent("ShowCharacterSelection", new Dictionary<string, string>
            {
                {"ReadyEvent", "OnFillCharacters"},
            });
        }

        [RemoteEvent("SelectCharacter")]
        public void SelectCharacter(Client player, uint id)
        {
            // TODO Creator-Fertigstellen
            player.TriggerEvent("hideBrowser");
            player.TriggerEvent("ResetCamera");
            player.Position = new Vector3(0, 0, 0);
            //Char Creator Start
        }

        [Command("veh")]
        public void VehCommand(Client player, VehicleHash name)
        {
            var veh = NAPI.Vehicle.CreateVehicle(name, new Vector3(0, 0, 0), new Vector3(0, 0, 0), 0, 0);
            veh.Dimension = player.Dimension;
            player.SetIntoVehicle(veh, -1);

        }
    }
}
