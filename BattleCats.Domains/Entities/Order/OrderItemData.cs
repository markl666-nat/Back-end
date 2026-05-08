using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Order
{
    /// <summary>
    /// Один товар внутри заказа.
    /// Зависимая сущность — ссылается на OrderData через OrderId (FK).
    /// </summary>
    public class OrderItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderData Order { get; set; } = null!;

        public string ProductInfo { get; set; } = string.Empty;
        public int Qua { get; set; }      // quantity, имя как у препода

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Discount { get; set; }
    }
}