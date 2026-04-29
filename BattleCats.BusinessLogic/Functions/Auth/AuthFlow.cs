using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCats.BusinessLogic.Core.Auth;
using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public object? LoginActionFlow(UserAuthAction auth)
        {
            var isValid = ValidateLogin(auth);
            return isValid ? GenToken(auth) : null;
        }
    }
}
