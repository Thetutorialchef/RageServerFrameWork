using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Server.resources.rsf.Models;

namespace rsf.Models
{
    public class AccountModel
    {
        [Key] public uint Id { get; set; }
        public string SocialClubName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TeamSpeakUniqueId { get; set; }
        public int WhiteListed { get; set; }
        public DateTime? EndBannedTime { get; set; }
        public string Ip { get; set; }
        public int RoleId { get; set; }
        public int MaxCharacters { get; set; } = 1;
        [NotMapped]
        public Client Player { get; set; }
        [NotMapped]
        public CharacterModel Character { get; set; }

        public void Spawn()
        {
            if (Character == null || Player == null) return;
            Player.TriggerEvent("Freeze", false);
            Player.SetSkin(Character.Geschlecht ? PedHash.FreemodeFemale01 : PedHash.FreemodeMale01);
            Player.Position = new Vector3(Character.PosX, Character.PosY, Character.PosZ);
            Player.Rotation = new Vector3(Character.RotX, Character.RotY, Character.RotZ);

            if (Character.Blend == null || Character.Daten == null || Character.FaceFeatures == null) return;
            Player.SetHeadOverlay(0, new HeadOverlay { Index = Character.Daten.Blemish, Opacity = Character.Daten.BlemishOpacity, Color = Character.Daten.BlemishPrimaryColor, SecondaryColor = Character.Daten.BlemishSecondaryColor });
            Player.SetHeadOverlay(1, new HeadOverlay { Index = Character.Daten.FacialHair, Opacity = Character.Daten.FacialHairOpacity, Color = Character.Daten.FacialHairPrimaryColor, SecondaryColor = Character.Daten.FacialHairSecondaryColor });
            Player.SetHeadOverlay(2, new HeadOverlay { Index = Character.Daten.Eyebrows, Opacity = Character.Daten.EyebrowsOpacity, Color = Character.Daten.EyebrowsPrimaryColor, SecondaryColor = Character.Daten.EyebrowsSecondaryColor });
            Player.SetHeadOverlay(3, new HeadOverlay { Index = Character.Daten.Ageing, Opacity = Character.Daten.AgeingOpacity, Color = Character.Daten.AgeingPrimaryColor, SecondaryColor = Character.Daten.AgeingSecondaryColor });
            Player.SetHeadOverlay(4, new HeadOverlay { Index = Character.Daten.Makeup, Opacity = Character.Daten.MakeupOpacity, Color = Character.Daten.MakeupPrimaryColor, SecondaryColor = Character.Daten.MakeupSecondaryColor });
            Player.SetHeadOverlay(5, new HeadOverlay { Index = Character.Daten.Blush, Opacity = Character.Daten.BlushOpacity, Color = Character.Daten.BlushPrimaryColor, SecondaryColor = Character.Daten.BlushSecondaryColor });
            Player.SetHeadOverlay(6, new HeadOverlay { Index = Character.Daten.Complexion, Opacity = Character.Daten.ComplexionOpacity, Color = Character.Daten.ComplexionPrimaryColor, SecondaryColor = Character.Daten.ComplexionSecondaryColor });
            Player.SetHeadOverlay(7, new HeadOverlay { Index = Character.Daten.SunDamage, Opacity = Character.Daten.SunDamageOpacity, Color = Character.Daten.SunDamagePrimaryColor, SecondaryColor = Character.Daten.SunDamageSecondaryColor });
            Player.SetHeadOverlay(8, new HeadOverlay { Index = Character.Daten.Lipstick, Opacity = Character.Daten.LipstickOpacity, Color = Character.Daten.LipstickPrimaryColor, SecondaryColor = Character.Daten.LipstickSecondaryColor });
            Player.SetHeadOverlay(9, new HeadOverlay { Index = Character.Daten.Moles, Opacity = Character.Daten.MolesOpacity, Color = Character.Daten.MolesPrimaryColor, SecondaryColor = Character.Daten.MolesSecondaryColor });
            Player.SetHeadOverlay(10, new HeadOverlay { Index = Character.Daten.ChestHair, Opacity = Character.Daten.ChestHairOpacity, Color = Character.Daten.ChestHairPrimaryColor, SecondaryColor = Character.Daten.ChestHairSecondaryColor });
            Player.SetHeadOverlay(11, new HeadOverlay { Index = Character.Daten.BodyBlemish, Opacity = Character.Daten.BodyBlemishOpacity, Color = Character.Daten.BodyBlemishPrimaryColor, SecondaryColor = Character.Daten.BodyBlemishSecondaryColor });

            NAPI.Player.SetPlayerHeadBlend(Player, new HeadBlend
            {
                ShapeFirst = Character.Blend.ShapeFirst,
                ShapeSecond = Character.Blend.ShapeSecond,
                ShapeMix = Character.Blend.ShapeMix,
                SkinFirst = Character.Blend.SkinFirst,
                SkinSecond = Character.Blend.SkinSecond,
                SkinMix = Character.Blend.SkinMix,
                ShapeThird = 0,
                SkinThird = 0,
                ThirdMix = 0
            });
            Player.SetFaceFeature(0, Character.FaceFeatures.Nasenbreite);
            Player.SetFaceFeature(1, Character.FaceFeatures.Nasenhoehe);
            Player.SetFaceFeature(2, Character.FaceFeatures.Nasenlaenge);
            Player.SetFaceFeature(3, Character.FaceFeatures.Nasenruecken);
            Player.SetFaceFeature(4, Character.FaceFeatures.Nasenspitze);
            Player.SetFaceFeature(5, Character.FaceFeatures.Nasenrueckenverschiebung);
            Player.SetFaceFeature(6, Character.FaceFeatures.Brauenhoehe);
            Player.SetFaceFeature(7, Character.FaceFeatures.Brauenbreite);
            Player.SetFaceFeature(8, Character.FaceFeatures.Wangenknochenhoehe);
            Player.SetFaceFeature(9, Character.FaceFeatures.Wangenknochenbreite);
            Player.SetFaceFeature(10, Character.FaceFeatures.Backenbreite);
            Player.SetFaceFeature(11, Character.FaceFeatures.Augen);
            Player.SetFaceFeature(12, Character.FaceFeatures.Lippen);
            Player.SetFaceFeature(13, Character.FaceFeatures.Backenbreite);
            Player.SetFaceFeature(14, Character.FaceFeatures.Backenhoehe);
            Player.SetFaceFeature(15, Character.FaceFeatures.Kinnlaenge);
            Player.SetFaceFeature(16, Character.FaceFeatures.Kinnposition);
            Player.SetFaceFeature(17, Character.FaceFeatures.Kinnbreite);
            Player.SetFaceFeature(18, Character.FaceFeatures.Kinnform);
            Player.SetFaceFeature(19, Character.FaceFeatures.Halsbreite);

            Player.SetClothes(2, Character.Daten.Frisur, 0);
            NAPI.Player.SetPlayerHairColor(Player, Character.Daten.FrisurFarbe, Character.Daten.FrisurHighlights);
        }

        public void Save()
        {
            if (Character == null) return;
            Character.PosX = Player.Position.X;
            Character.PosY = Player.Position.Y;
            Character.PosZ = Player.Position.Z;

            Character.RotX = Player.Rotation.X;
            Character.RotY = Player.Rotation.Y;
            Character.RotZ = Player.Rotation.Z;
        }
    }
}