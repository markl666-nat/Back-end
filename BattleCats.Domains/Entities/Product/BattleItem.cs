using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BattleCats.Domain.Entities.Refs;
using BattleCats.Domain.Enums;

namespace BattleCats.Domain.Entities.Product
{
    /// <summary>
    /// Главная сущность товара в магазине Cat Base Shop.
    /// В контексте игры Battle Cats — это юнит-кот, баф, гача-капсула и т.д.
    /// Наследует BaseStoreEntity для трекинга времени создания/обновления.
    /// </summary>
    public class BattleItem : BaseStoreEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Название товара (имя кота, название бафа). На фронте — title.</summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        /// <summary>Связь с описанием (one-to-one, опционально).</summary>
        public BattleItemLore? Lore { get; set; }

        /// <summary>Связь с категорией (many-to-one).</summary>
        public ItemCategory Category { get; set; } = null!;

        /// <summary>Список изображений (one-to-many).</summary>
        public List<ProductImgData> Images { get; set; } = new();

        /// <summary>Цена в евро. На фронте — priceEuro.</summary>
        public decimal PriceEuro { get; set; }

        /// <summary>Статус доступности товара (Active/Hidden/Deleted).</summary>
        public ItemAvailability Status { get; set; } = ItemAvailability.Active;
    }
}