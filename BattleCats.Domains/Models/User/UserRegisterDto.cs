using BattleCats.Domains.Enums;

namespace BattleCats.Domains.Models.User
{
    
    public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Contacts { get; set; }
        public DateTime DOB { get; set; }
        public GenderTypes Gender { get; set; }
    }
}