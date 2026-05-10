using BattleCats.BusinessLogic.Core.Auth;
using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Functions.Auth
{
    /// <summary>
    /// Поток операций с пользователями. Тонкая обёртка над UserActions.
    /// </summary>
    public class UserFlow : UserActions, IUserActions
    {
        public List<UserListDto> GetAllUsers()
        {
            return GetAllUsersExecution();
        }

        public ResponceMsg ChangeUserRole(UserChangeRoleDto data)
        {
            return ChangeUserRoleExecution(data);
        }

        public ResponceMsg DeleteUser(int id)
        {
            return DeleteUserExecution(id);
        }
    }
}