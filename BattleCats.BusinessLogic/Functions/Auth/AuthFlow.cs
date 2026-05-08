using BattleCats.BusinessLogic.Core.Auth;
using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Functions.Auth
{
    /// <summary>
    /// Поток обработки логина. Тонкая обёртка над AuthActions:
    /// валидируем учётку → если ок, выдаём токен → возвращаем ResponceAction.
    /// </summary>
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponceAction LoginActionFlow(UserAuthAction auth)
        {
            var user = ValidateLoginExecution(auth);

            if (user == null)
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            var token = GenerateUserToken(user);

            return new ResponceAction
            {
                IsSuccess = true,
                Message = token,    // ← в Message лежит JWT
                Id = user.Id
            };
        }
    }
}