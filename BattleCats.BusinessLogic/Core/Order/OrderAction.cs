using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Order;

namespace BattleCats.BusinessLogic.Core.Order
{
    
    public class OrderAction
    {
        protected List<OrderDto> GetAllOrdersAction()
        {
            return new List<OrderDto>();
        }

        protected OrderDto GetOrderByIdAction(int id)
        {
            return new OrderDto();
        }

        protected ResponceAction CreateOrderAction(OrderDto order)
        {
            return new ResponceAction();
        }

        protected ResponceMsg UpdateOrderAction(OrderDto order)
        {
            return new ResponceMsg();
        }

        protected ResponceMsg DeleteOrderAction(int id)
        {
            return new ResponceMsg();
        }
    }
}