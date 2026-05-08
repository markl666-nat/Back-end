using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Order;

namespace BattleCats.BusinessLogic.Interface
{
    /// <summary>
    /// Интерфейс CRUD-операций с заказами.
    /// Create возвращает ResponceAction (с Id нового заказа).
    /// Update/Delete возвращают ResponceMsg (без Id).
    /// </summary>
    public interface IOrderAction
    {
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderItem(int id);
        ResponceAction CreateOrder(OrderDto order);
        ResponceMsg UpdateOrder(OrderDto order);
        ResponceMsg DeleteOrder(int id);
    }
}