using BattleCats.BusinessLogic.Functions.Auth;
using BattleCats.BusinessLogic.Functions.Order;
using BattleCats.BusinessLogic.Functions.Products;
using BattleCats.BusinessLogic.Interface;

namespace BattleCats.BusinessLogic
{
    /// <summary>
    /// Главный фасад BusinessLogic.
    /// API-контроллеры создают экземпляр этого класса и через геттеры получают
    /// нужный интерфейс. Каждый Get* возвращает свежий Flow-объект.
    /// </summary>
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
    }
}