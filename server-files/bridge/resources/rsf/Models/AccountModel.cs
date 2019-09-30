using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace rsf.Models
{
    public class AccountModel
    {
        [Key] public uint Id { get; set; }
        public string SocialClubName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TeamSpeakUniqueId { get; set; }
        public int WhiteListed { get; set; }
        public DateTime? EndBannedTime { get; set; }
        public string Ip { get; set; }
        public int RoleId { get; set; }
        public int MaxCharacters { get; set; } = 1;
        public virtual ICollection<CharacterModel> Characters { get; set; }
    }
}