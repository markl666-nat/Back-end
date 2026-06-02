using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.User;

namespace BattleCats.BusinessLogic.Interface
{
    
    public interface IAuthActions
    {
        ResponceAction LoginActionFlow(UserAuthAction auth);
    }
}