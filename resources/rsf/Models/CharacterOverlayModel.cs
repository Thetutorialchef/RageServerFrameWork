using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace rsf.Models
{
    public class CharacterOverlayModel
    {
        public static Dictionary<byte, string> Names = new Dictionary<byte, string>
        {
            {0, "Schönheitsfehler"},
            {1, "Gesichtsbehaarung"},
            {2, "Augenbrauen"},
            {3, "Alterung"},
            {4, "Make-up"},
            {5, "Erröten"},
            {6, "Teint"},
            {7, "Sonnenschäden"},
            {8, "Lippenstift"},
            {9, "Schönheitsfleck"},
            {10, "Brusthaar"},
            {11, "Körperunreinheiten"}
            // Frisur
            // Haarfarbe
            // Haarhighlights
        };

        public static Dictionary<byte, uint> MaxAvailable = new Dictionary<byte, uint> // ex. MaxAvailable[ChestHair]
        {
            {0, 23},
            {1, 28},
            {2, 33},
            {3, 14},
            {4, 74},
            {5, 6},
            {6, 11},
            {7, 10},
            {8, 9},
            {9, 17},
            {10, 16},
            {11, 11}
        };

        [Key] public uint Id { get; set; }

        public uint CharacterModelId { get; set; }
        public CharacterModel CharacterModel { get; set; }

        public ushort Schriftart { get; set; }

        public byte Blemish { get; set; }
        public byte BlemishPrimaryColor { get; set; }
        public byte BlemishSecondaryColor { get; set; }
        public float BlemishOpacity { get; set; } = 1;

        public byte FacialHair { get; set; }
        public byte FacialHairPrimaryColor { get; set; }
        public byte FacialHairSecondaryColor { get; set; }
        public float FacialHairOpacity { get; set; } = 1;

        public byte Eyebrows { get; set; }
        public byte EyebrowsPrimaryColor { get; set; }
        public byte EyebrowsSecondaryColor { get; set; }
        public float EyebrowsOpacity { get; set; } = 1;

        public byte Ageing { get; set; }
        public byte AgeingPrimaryColor { get; set; }
        public byte AgeingSecondaryColor { get; set; }
        public float AgeingOpacity { get; set; } = 1;

        public byte Makeup { get; set; }
        public byte MakeupPrimaryColor { get; set; }
        public byte MakeupSecondaryColor { get; set; }
        public float MakeupOpacity { get; set; } = 1;


        public byte Blush { get; set; }
        public byte BlushPrimaryColor { get; set; }
        public byte BlushSecondaryColor { get; set; }
        public float BlushOpacity { get; set; } = 1;

        public byte Complexion { get; set; }
        public byte ComplexionPrimaryColor { get; set; }
        public byte ComplexionSecondaryColor { get; set; }
        public float ComplexionOpacity { get; set; } = 1;

        public byte SunDamage { get; set; }
        public byte SunDamagePrimaryColor { get; set; }
        public byte SunDamageSecondaryColor { get; set; }
        public float SunDamageOpacity { get; set; } = 1;

        public byte Lipstick { get; set; }
        public byte LipstickPrimaryColor { get; set; }
        public byte LipstickSecondaryColor { get; set; }
        public float LipstickOpacity { get; set; } = 1;

        public byte Moles { get; set; }
        public byte MolesPrimaryColor { get; set; }
        public byte MolesSecondaryColor { get; set; }
        public float MolesOpacity { get; set; } = 1;

        public byte ChestHair { get; set; }
        public byte ChestHairPrimaryColor { get; set; }
        public byte ChestHairSecondaryColor { get; set; }
        public float ChestHairOpacity { get; set; } = 1;

        public byte BodyBlemish { get; set; }
        public byte BodyBlemishPrimaryColor { get; set; }
        public byte BodyBlemishSecondaryColor { get; set; }
        public float BodyBlemishOpacity { get; set; } = 1;

        public int Frisur { get; set; }
        public byte FrisurFarbe { get; set; }
        public byte FrisurHighlights { get; set; }

    }
}