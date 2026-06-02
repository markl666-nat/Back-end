namespace BattleCats.Domains.Models.User
{
   
    public class UserAuthAction
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}