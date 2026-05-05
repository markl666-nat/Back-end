namespace BattleCats.Domain.Enums
{
    /// <summary>
    /// Статус доступности товара в магазине Battle Cats.
    /// Используется в BattleItem для управления видимостью в каталоге.
    /// </summary>
    public enum ItemAvailability
    {
        /// <summary>Товар активен и виден в каталоге.</summary>
        Active = 0,

        /// <summary>Товар скрыт (например, временно недоступен).</summary>
        Hidden = 1,

        /// <summary>Товар удалён (для soft-delete).</summary>
        Deleted = 2
    }
}