using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient.X.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using rsf.Data;

namespace rsf.Models
{
    public class CharacterModel
    {
        [Key] public uint Id { get; set; }
        public uint AccountModelId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Vorname { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Geburtsort { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Staatsangehoerigkeit { get; set; }
        public bool Geschlecht { get; set; } // false = Männlich, true = Weiblich
        public byte Familienstand { get; set; } // 0 = ledig, 1 = verheiratet, 2 = getrennt, 3 = geschieden, 4 = verwitwet
        public byte Schriftart { get; set; }

        public int Dead { get; set; }

        public int RoleId { get; set; } // Anderer Name für "Rollen / Status" Zivilist, WhiteListedJobs  

        public int AccountBalance { get; set; }

        public double Money { get; set; } = 5000;

        public int JobRank { get; set; } // z.b. Chef, Azubi, Angestellter

        public WhiteListedJobType WJobId { get; set; } // WhiteListed Jobs --- Enum muss zur Enum Class umgenannt werden

        public int OnDuty { get; set; }

        public JobType JobId { get; set; }

        /// Non WhiteListed Jobs

        public int Jail { get; set; }

        public int Jailtime { get; set; }

        public double Bank { get; set; } // Guthaben auf der Bank

        public CharacterSex Sex { get; set; }

        public int Wantedlevel { get; set; }

        public AccountModel AccountModel { get; set; }

        // public double[] LastLocation { get; set; } = new double[] { -1167.994, -700.4285, 21.89281 }; // Letzte Position
    }
}