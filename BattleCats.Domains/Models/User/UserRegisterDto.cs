using BattleCats.Domains.Enums;

namespace BattleCats.Domains.Models.User
{
    /// <summary>
    /// DTO для регистрации нового пользователя.
    /// Принимается контроллером /api/reg.
    /// Пароль приходит в plain text, хешируется через PasswordHasher в RegisterActions.
    /// Роль не указывается клиентом (всегда User по умолчанию, чтобы юзер не мог зарегаться админом).
    /// </summary>
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