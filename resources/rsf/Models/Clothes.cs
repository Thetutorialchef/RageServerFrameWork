using System.ComponentModel.DataAnnotations;
using GTANetworkAPI;

namespace Server.resources.rsf.Models
{
    public class Clothes : Script
    {
        [Key]
        public uint Id { get; set; }
        public int Drawable { get; set; }
        public int Texture { get; set; }
        public int TorsoDrawable { get; set; }
        public int TorsoTexture { get; set; }
        public int UnterhemdDrawable { get; set; }
        public int UnterhemdTexture { get; set; }
        public bool Geschlecht { get; set; }

    }
}