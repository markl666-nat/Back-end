using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCatsStore.Domains.Entities.Products
{
    public class BattleItemLore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoreId { get; set; } // Сменили Id на LoreId

        [Required]
        [StringLength(300)] // Чуть увеличили для смешных описаний
        public string? FlavorText { get; set; } // Сменили Description на FlavorText

        // Задел на будущее: меняем DescriptionAdvanced на CombatStats
        public int CombatStatsId { get; set; }
        public CombatStats AdvancedStats { get; set; } // Здесь будут HP, Урон, Дальность
    }
}