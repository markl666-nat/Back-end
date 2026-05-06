namespace BattleCats.Domains.Entities.Refs
{
    /// <summary>
    /// Базовый класс для всех Entity, которые нужно отслеживать по времени.
    /// Содержит общие поля CreatedAt и UpdatedAt.
    /// От него наследуется BattleItem (товар).
    /// </summary>
    public class BaseStoreEntity
    {
        /// <summary>Дата создания записи в базе.</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Дата последнего обновления.</summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}