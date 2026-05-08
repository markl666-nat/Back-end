using BattleCats.BusinessLogic.Core.Order;
using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Order;

namespace BattleCats.BusinessLogic.Functions.Order
{
    /// <summary>
    /// Поток операций с заказами. Тонкая обёртка над OrderAction.
    /// </summary>
    public class OrderFlow : OrderAction, IOrderAction
    {
        public List<OrderDto> GetAllOrders()
        {
            return GetAllOrdersAction();
        }

        public OrderDto GetOrderItem(int id)
        {
            return GetOrderByIdAction(id);
        }

        public ResponceAction CreateOrder(OrderDto order)
        {
            return CreateOrderAction(order);
        }

        public ResponceMsg UpdateOrder(OrderDto order)
        {
            return UpdateOrderAction(order);
        }

        public ResponceMsg DeleteOrder(int id)
        {
            return DeleteOrderAction(id);
        }
    }
}