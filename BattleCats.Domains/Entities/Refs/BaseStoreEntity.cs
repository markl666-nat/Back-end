namespace BattleCats.Domains.Entities.Refs
{
    
    public class BaseStoreEntity
    {
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}