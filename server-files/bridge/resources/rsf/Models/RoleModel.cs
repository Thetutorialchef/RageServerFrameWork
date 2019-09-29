using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rsf.Models
{
   public class RoleModel
    {
        [Key]
        public int RoleID { get; set; }

        public string Name { get; set; }
    }
}
