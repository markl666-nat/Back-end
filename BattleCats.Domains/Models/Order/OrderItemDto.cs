namespace BattleCats.Domains.Models.Order
{
    
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ProductInfo { get; set; } = string.Empty;
        public int Qua { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}