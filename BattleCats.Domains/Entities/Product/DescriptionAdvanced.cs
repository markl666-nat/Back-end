using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Product
{
    /// <summary>
    /// Расширенные характеристики товара (для боевых юнитов Battle Cats).
    /// Связь с BattleItemLore — one-to-one (одно описание = одни характеристики).
    /// Используется для демонстрации вложенной 1:1 связи в EF Core.
    /// </summary>
    public class DescriptionAdvanced
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Здоровье юнита (Health).</summary>
        public int Health { get; set; }

        /// <summary>Атака юнита (Attack damage).</summary>
        public int Attack { get; set; }

        /// <summary>Дальность атаки (Attack range).</summary>
        public int Range { get; set; }
    }
}