using BattleCats.BusinessLogic.Functions.Auth;
using BattleCats.BusinessLogic.Functions.Order;
using BattleCats.BusinessLogic.Functions.Products;
using BattleCats.BusinessLogic.Interface;

namespace BattleCats.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public IRegisterActions GetRegisterActions()
        {
            return new RegisterFlow();
        }

        public IBattleItem GetBattleItemActions()
        {
            return new BattleItemFlow();
        }

        public IOrderAction GetOrderActions()
        {
            return new OrderFlow();
        }

        public IUserActions GetUserActions()
        {
            return new UserFlow();
        }
    }
}