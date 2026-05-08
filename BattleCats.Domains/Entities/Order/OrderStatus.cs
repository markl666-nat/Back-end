namespace BattleCats.Domains.Entities.Order
{
    /// <summary>
    /// Статус заказа в магазине Cat Base Shop.
    /// "Aceepted" — опечатка препода (правильно "Accepted"), оставляем для 1-в-1.
    /// </summary>
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