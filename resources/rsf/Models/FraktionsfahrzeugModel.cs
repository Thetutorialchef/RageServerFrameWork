using System.ComponentModel.DataAnnotations;

namespace Server.resources.rsf.Models
{
    public class FraktionsfahrzeugModel : Fahrzeug
    {
        [Key]
        public uint Id { get; set; }
        public uint FraktionenModelId { get; set; }
        public FraktionenModel FraktionenModel { get; set; }

        public new void Spawn()
        {
            base.Spawn();
            Vehicle.SetData("Fraktionsfahrzeug", this);
        }
    }

}