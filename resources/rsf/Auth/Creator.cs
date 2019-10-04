using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;
using rsf.Database;
using rsf.Models;
using Server.resources.rsf.Models;

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
            using var ctx = new DefaultDbContext();
            var character = ctx.Characters.FirstOrDefault(t => t.Id == id);
            if (character == null) return;

            player.TriggerEvent("hideBrowser");
            player.TriggerEvent("ResetCamera");

            AccountModel acc = player.GetData("User");

            acc.Character = character;
            if (ctx.CharacterOverlay.Count(t => t.CharacterModelId == id) == 0)
            {
                player.TriggerEvent("OnCreatorStart", CharacterOverlayModel.MaxAvailable, CharacterOverlayModel.Names, acc.Character.Geschlecht);
                player.Position = new Vector3(402.8664, -996.4108, -99.00027);
                player.Rotation = new Vector3(0.0, 0.0, 167);
                player.SetSkin(acc.Character.Geschlecht ? PedHash.FreemodeFemale01 : PedHash.FreemodeMale01);
                player.TriggerEvent("Freeze", true);
            }
            else
            {
                acc.Character.Daten = ctx.CharacterOverlay.FirstOrDefault(t => t.CharacterModelId == id);
                acc.Character.FaceFeatures = ctx.CharacterFeatures.FirstOrDefault(t => t.CharacterModelId == id);
                acc.Character.Blend = ctx.CharacterBlend.FirstOrDefault(t => t.CharacterModelId == id);
                acc.Spawn();
            }


            //Char Creator Start
        }

        [RemoteEvent("OnCreatorSave")]
        public void OnCreatorSave(Client player, string overlay, string blend, string faceFeatures)
        {
            using var ctx = new DefaultDbContext();
            player.TriggerEvent("OnCreatorStop");
            player.TriggerEvent("Freeze", false);
            AccountModel acc = player.GetData("User");
            var characterOverlay = JsonConvert.DeserializeObject<CharacterOverlayModel>(overlay);
            characterOverlay.CharacterModelId = acc.Character.Id;
            ctx.CharacterOverlay.Add(characterOverlay);
            ctx.SaveChanges();

            var characterBlend = JsonConvert.DeserializeObject<CharacterBlendModel>(blend);
            characterBlend.CharacterModelId = acc.Character.Id;
            ctx.CharacterBlend.Add(characterBlend);
            ctx.SaveChanges();

            var characterFaceFeatures = JsonConvert.DeserializeObject<CharacterFeaturesModel>(faceFeatures);
            characterFaceFeatures.CharacterModelId = acc.Character.Id;
            ctx.CharacterFeatures.Add(characterFaceFeatures);
            ctx.SaveChanges();


            acc.Character.Daten = ctx.CharacterOverlay.FirstOrDefault(t => t.CharacterModelId == acc.Character.Id);
            acc.Character.FaceFeatures = ctx.CharacterFeatures.FirstOrDefault(t => t.CharacterModelId == acc.Character.Id);
            acc.Character.Blend = ctx.CharacterBlend.FirstOrDefault(t => t.CharacterModelId == acc.Character.Id);
            acc.Spawn();
        }
    }
}
