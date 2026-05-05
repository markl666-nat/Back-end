using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domain.Entities.Product
{
    /// <summary>
    /// Категория товара в магазине Battle Cats.
    /// Возможные значения (хранятся как записи в БД через seed):
    /// "Cat Units", "Base Upgrades", "Buffs", "Gacha".
    /// Связь с BattleItem — many-to-one (одна категория содержит много товаров).
    /// </summary>
    public class ItemCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название категории. Совпадает со значениями на фронте (types.ts):
        /// "Cat Units", "Base Upgrades", "Buffs", "Gacha".
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}