using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCats.Domains.Entities.Refs;
using BattleCats.Domains.Enums;

namespace BattleCatsStore.Domains.Entities.Products
{
    [Table("BattleCats_Inventory")] // Маскировка таблицы
    public class BattleItem : BaseStoreEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternalId { get; set; } // Сменили Id на InternalId

        [Required]
        [MaxLength(80)]
        public string ItemName { get; set; } // Имя кота или название баффа

        public decimal CatFoodPrice { get; set; } // Валюта в игре — Cat Food (Кетфуд)

        // Новые уникальные поля под тему игры
        public string RarityTier { get; set; } // Rare, Super Rare, Uber Super Rare
        public int PowerLevel { get; set; } // Уровень силы (важно для котов)

        // Связь с категорией (Коты / Баффы / Плюши)
        public int CategoryId { get; set; }
        public virtual ItemCategory Group { get; set; }

        public virtual ICollection<ItemAsset> Assets { get; set; } // Спрайты или фото игрушек
        public ProductStatus StockStatus { get; set; }
    }
}