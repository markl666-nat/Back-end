using BattleCats.BusinessLogic.Structure;
using BattleCats.DataAccess.Context;
using BattleCats.Domains.Entities.User;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Core.Auth
{
    /// <summary>
    /// Низкоуровневая операция регистрации нового юзера.
    /// Проверяет уникальность UserName/Email, хеширует пароль, ставит роль User по умолчанию.
    /// </summary>
    public class RegisterActions
    {
        internal ResponceAction RegisterUserExecution(UserRegisterDto uReg)
        {
            // Базовая валидация обязательных полей
            if (string.IsNullOrEmpty(uReg.UserName) ||
                string.IsNullOrEmpty(uReg.Password) ||
                string.IsNullOrEmpty(uReg.Email))
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "UserName, Password and Email are required."
                };
            }

            // Проверка уникальности
            UserData? existing;
            using (var db = new UserContext())
            {
                existing = db.Users.FirstOrDefault(
                    u => u.Email == uReg.Email || u.UserName == uReg.UserName);
            }

            if (existing != null)
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "Email or username already exists."
                };
            }

            // Создаём юзера с дефолтной ролью User и захешированным паролем
            var user = new UserData
            {
                UserName = uReg.UserName,
                Password = PasswordHasher.Hash(uReg.Password),
                Email = uReg.Email,
                Contacts = uReg.Contacts ?? string.Empty,
                DOB = uReg.DOB,
                Gender = uReg.Gender,
                Role = UserRole.User
            };

            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return new ResponceAction
            {
                IsSuccess = true,
                Message = "User registration successful.",
                Id = user.Id
            };
        }
    }
}