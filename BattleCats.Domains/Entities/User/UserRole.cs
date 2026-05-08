namespace BattleCats.Domains.Entities.User
{
    /// <summary>
    /// Роли пользователей в Cat Base Shop.
    /// User — обычный покупатель (роль по умолчанию при регистрации).
    /// Manager — может создавать/обновлять боевых юнитов и заказы.
    /// Admin — полный контроль, включая удаление.
    /// 
    /// Числовые значения 1/20/30 как у препода — оставлен запас на промежуточные роли.
    /// </summary>
    public enum UserRole
    {
        User = 1,
        Manager = 20,
        Admin = 30
    }
}