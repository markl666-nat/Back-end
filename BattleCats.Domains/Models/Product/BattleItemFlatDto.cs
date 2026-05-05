namespace BattleCats.Domain.Models.Product
{
    /// <summary>
    /// Плоский DTO товара для возврата на фронт.
    /// Структура совпадает с типом Product в types.ts на фронте.
    /// Создаётся из BattleItem через AutoMapper (Лаба 3).
    /// </summary>
    public class BattleItemFlatDto
    {
        /// <summary>Совпадает с фронтовым 'id'.</summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>Совпадает с фронтовым 'title' (мапится из Name).</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Совпадает с фронтовым 'description' (мапится из Lore.Description).</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>Совпадает с фронтовым 'priceEuro'.</summary>
        public decimal PriceEuro { get; set; }

        /// <summary>Название категории строкой ("Cat Units", "Buffs", и т.д.).</summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>URL первого изображения товара.</summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}