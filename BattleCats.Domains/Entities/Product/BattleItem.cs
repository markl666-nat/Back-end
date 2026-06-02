using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BattleCats.Domains.Entities.Refs;
using BattleCats.Domains.Enums;

namespace BattleCats.Domains.Entities.Product
{
    
    public class BattleItem : BaseStoreEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

       
        public BattleItemLore? Lore { get; set; }

        
        public ItemCategory Category { get; set; } = null!;

        
        public List<ProductImgData> Images { get; set; } = new();

        
        [Column(TypeName = "decimal(10,2)")]
        public decimal PriceEuro { get; set; }

        
        public ItemAvailability Status { get; set; } = ItemAvailability.Active;
    }
}