using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Interface
{
    /// <summary>
    /// Интерфейс операций аутентификации.
    /// LoginActionFlow возвращает ResponceAction:
    ///   - IsSuccess=true + Message=JWT-токен + Id=userId — при успехе
    ///   - IsSuccess=false + Message=причина — при провале
    /// </summary>
    public interface IAuthActions
    {
        ResponceAction LoginActionFlow(UserAuthAction auth);
    }
}