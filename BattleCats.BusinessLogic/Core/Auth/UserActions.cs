using BattleCats.DataAccess.Context;
using BattleCats.Domains.Entities.User;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Core.Auth
{
    /// <summary>
    /// Низкоуровневые операции CRUD над пользователями (для админки).
    /// </summary>
    public class UserActions
    {
        internal List<UserListDto> GetAllUsersExecution()
        {
            using (var db = new UserContext())
            {
                return db.Users
                    .Select(u => new UserListDto
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                        Role = u.Role,
                        DOB = u.DOB
                    })
                    .ToList();
            }
        }

        internal ResponceMsg ChangeUserRoleExecution(UserChangeRoleDto data)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == data.Id);
                if (user == null)
                {
                    return new ResponceMsg { IsSuccess = false, Message = "User not found." };
                }

                user.Role = data.NewRole;
                db.SaveChanges();

                return new ResponceMsg
                {
                    IsSuccess = true,
                    Message = $"User '{user.UserName}' role changed to {data.NewRole}."
                };
            }
        }

        internal ResponceMsg DeleteUserExecution(int id)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return new ResponceMsg { IsSuccess = false, Message = "User not found." };
                }

                db.Users.Remove(user);
                db.SaveChanges();

                return new ResponceMsg
                {
                    IsSuccess = true,
                    Message = $"User '{user.UserName}' deleted successfully."
                };
            }
        }
    }
}