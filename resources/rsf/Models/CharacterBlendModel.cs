using System.ComponentModel.DataAnnotations;
using rsf.Models;

namespace Server.resources.rsf.Models
{
    public class CharacterBlendModel
    {
        [Key]
        public uint Id { get; set; }
        public uint CharacterModelId { get; set; }
        public byte ShapeFirst { get; set; } // 0 - 45
        public float ShapeMix { get; set; } // 0.00 - 1.00 (0.01, 0.02..)
        public byte ShapeSecond { get; set; } // 0 - 45

        public byte SkinFirst { get; set; } // 0 - 45
        public float SkinMix { get; set; } // 0.00 - 1.00 (0.01, 0.02..)
        public byte SkinSecond { get; set; } // 0 - 45
        public CharacterModel CharacterModel { get; set; }
    }
}
