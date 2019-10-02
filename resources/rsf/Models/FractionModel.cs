using System.ComponentModel.DataAnnotations;

namespace rsf.Models
{
    public class FractionModel
    {
        [Key] public uint Id { get; set; }

        public string Name { get; set; }

        public int FractionLeaderId { get; set; }
    }
}