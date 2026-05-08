using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Interface
{
    /// <summary>
    /// Интерфейс операций регистрации.
    /// RegisterActionFlow возвращает ResponceAction:
    ///   - IsSuccess=true + Id=newUserId — при успехе
    ///   - IsSuccess=false + Message=причина — при провале
    /// </summary>
    public interface IRegisterActions
    {
        ResponceAction RegisterActionFlow(UserRegisterDto uReg);
    }
}