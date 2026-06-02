namespace BattleCats.Domains.Models.Product
{
    
    public class BattleItemFlatDto
    {
        
        public string Id { get; set; } = string.Empty;

        
        public string Title { get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;

        
        public decimal PriceEuro { get; set; }

       
        public string Category { get; set; } = string.Empty;

        
        public string ImageUrl { get; set; } = string.Empty;
    }
}