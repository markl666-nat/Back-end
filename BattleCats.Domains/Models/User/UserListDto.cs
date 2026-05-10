using BattleCats.Domains.Entities.User;

namespace BattleCats.Domains.Models.User
{
    /// <summary>
    /// DTO для списка пользователей в админ-панели.
    /// Возвращается через GET /api/user/getAll.
    /// 
    /// Не содержит Password — это публичный эндпоинт для админа,
    /// но хеши паролей наружу мы не выдаём принципиально.
    /// </summary>
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime DOB { get; set; }
    }

    /// <summary>
    /// DTO для запроса смены роли пользователя.
    /// Принимается в PUT /api/user/role.
    /// </summary>
    public class UserChangeRoleDto
    {
        public int Id { get; set; }
        public UserRole NewRole { get; set; }
    }
}