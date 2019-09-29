using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rsf.Models
{
    public class FractionModel
    {
        [Key]
        public int FractionID { get; set; }

        public string Name { get; set; }

        public int FractionLeaderID { get; set; }
    }
}
