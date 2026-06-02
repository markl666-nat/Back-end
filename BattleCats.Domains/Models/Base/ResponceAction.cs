namespace BattleCats.Domains.Models.Base
{
    
    public class ResponceAction
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}