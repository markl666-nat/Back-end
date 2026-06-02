using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Interface
{
    
    public interface IUserActions
    {
        List<UserListDto> GetAllUsers();
        ResponceMsg ChangeUserRole(UserChangeRoleDto data);
        ResponceMsg DeleteUser(int id);
    }
}