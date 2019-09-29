using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rsf.Models
{
   public class AccountModel
    {
        [Key]
        public int UserID { get; set; }

        public string SocialClubName { get; set; }

        public string ForumName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        
        public string Email { get; set; }

        public string TeamSpeakUniqueID { get; set; }

        public int Banned { get; set; }

        public int PermBanned { get; set; }

        public int WhiteListed { get; set; }

        public DateTime BeginBannedTime { get; set; }

        public DateTime EndBannedTime { get; set; }

        public string IP { get; set; }

        public int RoleID { get; set; }

        public int MaxCharacters { get; set; }

        public virtual ICollection<CharacterModel> Characters { get; set; }

    }
}
