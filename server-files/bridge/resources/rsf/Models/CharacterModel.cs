using System.ComponentModel.DataAnnotations;
using rsf.Data;

namespace rsf.Models
{
    public class CharacterModel
    {
        [Key] public uint Id { get; set; }
        public uint AccountModelId { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

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