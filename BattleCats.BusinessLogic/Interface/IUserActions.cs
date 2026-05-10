using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Interface
{
    /// <summary>
    /// Интерфейс для админских операций над пользователями.
    /// Все методы требуют роль Admin (проверяется на уровне контроллера).
    /// </summary>
    public interface IUserActions
    {
        List<UserListDto> GetAllUsers();
        ResponceMsg ChangeUserRole(UserChangeRoleDto data);
        ResponceMsg DeleteUser(int id);
    }
}