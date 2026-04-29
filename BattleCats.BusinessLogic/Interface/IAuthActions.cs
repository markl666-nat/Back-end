using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        object? LoginActionFlow(UserAuthAction auth);
    }
}
