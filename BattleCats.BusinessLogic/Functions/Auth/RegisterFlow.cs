using BattleCats.BusinessLogic.Core.Auth;
using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Functions.Auth
{
    
    public class RegisterFlow : RegisterActions, IRegisterActions
    {
        public ResponceAction RegisterActionFlow(UserRegisterDto uReg)
        {
            return RegisterUserExecution(uReg);
        }
    }
}