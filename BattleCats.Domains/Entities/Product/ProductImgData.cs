using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domain.Entities.Product
{
    /// <summary>
    /// Изображение товара. Один товар может иметь несколько изображений (галерея).
    /// Связь с BattleItem — many-to-one (много изображений → один товар).
    /// Используется для демонстрации 1:M связи в EF Core.
    /// </summary>
    public class ProductImgData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>URL изображения. Может быть локальный путь или внешний URL.</summary>
        [Required]
        [StringLength(500)]
        public string Url { get; set; } = string.Empty;

        /// <summary>FK на товар (один товар имеет много изображений).</summary>
        public int BattleItemId { get; set; }
    }
}