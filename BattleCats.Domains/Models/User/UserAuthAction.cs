namespace BattleCats.Domain.Models.User
{
    /// <summary>
    /// DTO для запросов логина и регистрации.
    /// Используется в AuthController при POST /api/auth/login и /api/auth/register.
    /// </summary>
    public class UserAuthAction
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}