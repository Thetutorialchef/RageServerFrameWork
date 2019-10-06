using System.ComponentModel.DataAnnotations;
using rsf.Models;

namespace Server.resources.rsf.Models
{
    public class CharacterFeaturesModel
    {
        [Key]
        public uint Id { get; set; }
        public uint CharacterModelId { get; set; }
        public float Nasenbreite { get; set; }
        public float Nasenhoehe { get; set; }
        public float Nasenlaenge { get; set; }
        public float Nasenruecken { get; set; }
        public float Nasenspitze { get; set; }
        public float Nasenrueckenverschiebung { get; set; }
        public float Brauenhoehe { get; set; }
        public float Brauenbreite { get; set; }
        public float Wangenknochenhoehe { get; set; }
        public float Wangenknochenbreite { get; set; }
        public float Wangenbreite { get; set; }
        public float Augen { get; set; }
        public float Lippen { get; set; }
        public float Backenbreite { get; set; }
        public float Backenhoehe { get; set; }
        public float Kinnlaenge { get; set; }
        public float Kinnposition { get; set; }
        public float Kinnbreite { get; set; }
        public float Kinnform { get; set; }
        public float Halsbreite { get; set; }
        public CharacterModel CharacterModel { get; set; }
    }
}