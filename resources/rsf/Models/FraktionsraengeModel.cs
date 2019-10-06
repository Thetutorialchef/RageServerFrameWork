using System.ComponentModel.DataAnnotations;

namespace Server.resources.rsf.Models
{
    public class FraktionsraengeModel
    {
        [Key] public uint Id { get; set; }
        public byte Rang { get; set; }
        public string Name { get; set; }
        public double Betrag { get; set; }
        public uint FraktionenModelId { get; set; }
        public FraktionenModel FraktionenModel { get; set; }
    }
}