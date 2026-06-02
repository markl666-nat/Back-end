namespace BattleCats.Domains.Entities.Order
{
    
    public enum OrderStatus
    {
        None,
        Declined,
        Aceepted,
        Validating,
        Paid,
        Delivered,
        Refund
    }
}