using BattleCats.BusinessLogic.Structure;
using BattleCats.DataAccess.Context;
using BattleCats.Domains.Entities.User;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Core.Auth
{
    
    public class AuthActions
    {
        internal UserData? ValidateLoginExecution(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
                return null;

            
            var passwordHash = PasswordHasher.Hash(data.Password);

            using (var db = new UserContext())
            {
               
                return db.Users.FirstOrDefault(
                    u => (u.UserName == data.Login || u.Email == data.Login)
                         && u.Password == passwordHash);
            }
        }

        internal string GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.UserName, user.Role.ToString());
        }
    }
}