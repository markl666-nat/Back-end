using BattleCats.Domains.Entities.Product;

namespace BattleCats.Domains.Models.Product
{
    
    public class BattleItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public BattleItemLore? Lore { get; set; }
        public ItemCategory Category { get; set; } = null!;
        public List<ProductImgData> Images { get; set; } = new();
        public decimal PriceEuro { get; set; }
    }
}