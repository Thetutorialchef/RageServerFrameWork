using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.resources.rsf.Models
{
    public class FraktionenModel
    {
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }
        public byte MaxRaenge { get; set; }
        public string Short { get; set; }
        [NotMapped]
        public FraktionskasseModel Kasse { get; set; }
        [NotMapped]
        public List<FraktionsfahrzeugModel> Fahrzeug { get; set; }
        [NotMapped]
        public List<FraktionsraengeModel> Raenge { get; set; }
    }

}