using System.ComponentModel.DataAnnotations;

namespace rsf.Models
{
    public class RoleModel
    {
        [Key] public uint Id { get; set; }

        public string Name { get; set; }
    }
}