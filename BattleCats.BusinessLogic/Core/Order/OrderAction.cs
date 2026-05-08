using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Order;

namespace BattleCats.BusinessLogic.Core.Order
{
    /// <summary>
    /// Низкоуровневые операции с заказами.
    /// 
    /// КУРСОВОЙ-ЗАГЛУШКА: возвращают пустые DTO/ответы.
    /// У препода в эталоне ровно так же — заглушки ради демонстрации структуры.
    /// Реальная логика заказов выходит за рамки темы магазина "просмотр + админ-CRUD",
    /// но контракт CRUD должен существовать для Лабы 3 (полный CRUD на каждой сущности).
    /// </summary>
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