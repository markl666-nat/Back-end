using BattleCats.BusinessLogic.Functions.Auth;
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

        public IProduct GetProductActions()
        {
            return new ProductFlow();
        }
    }
}
