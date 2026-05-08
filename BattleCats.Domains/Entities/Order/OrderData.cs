using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Order
{
    /// <summary>
    /// Заказ покупателя в Cat Base Shop.
    /// Содержит коллекцию позиций (OrderItemData), итоговую сумму и статус.
    /// IsDeleted используется для soft-delete вместо физического удаления.
    /// </summary>
    public class OrderData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [InverseProperty("Order")]
        public List<OrderItemData> Items { get; set; } = new();

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }
    }
}