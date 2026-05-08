using BattleCats.BusinessLogic.Structure;
using BattleCats.DataAccess.Context;
using BattleCats.Domains.Entities.User;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Core.Auth
{
    /// <summary>
    /// Низкоуровневые операции аутентификации.
    /// ValidateLoginExecution — поиск юзера в БД по логину/email + сверка хеша пароля.
    /// GenerateUserToken — обёртка над TokenService.
    /// 
    /// Эти методы protected — вызываются только из AuthFlow.
    /// </summary>
    public class AuthActions
    {
        internal UserData? ValidateLoginExecution(UserAuthAction data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
                return null;

            // Хешируем пришедший пароль и сравниваем с тем что в БД
            var passwordHash = PasswordHasher.Hash(data.Password);

            using (var db = new UserContext())
            {
                // Логин может быть либо username либо email — ищем по обоим полям
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