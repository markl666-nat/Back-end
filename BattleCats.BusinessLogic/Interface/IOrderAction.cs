using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Order;

namespace BattleCats.BusinessLogic.Interface
{
    
    public interface IOrderAction
    {
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderItem(int id);
        ResponceAction CreateOrder(OrderDto order);
        ResponceMsg UpdateOrder(OrderDto order);
        ResponceMsg DeleteOrder(int id);
    }
}