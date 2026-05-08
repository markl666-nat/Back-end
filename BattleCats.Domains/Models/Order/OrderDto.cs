using BattleCats.Domains.Entities.Order;

namespace BattleCats.Domains.Models.Order
{
    /// <summary>
    /// DTO заказа для API-контракта.
    /// Включает список позиций. Возвращается в OrderController.
    /// </summary>
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}