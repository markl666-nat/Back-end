using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Product
{
    /// <summary>
    /// Подробное описание товара (лор юнита, описание бафа и т.д.).
    /// Связь с BattleItem — one-to-one (один товар = одно описание).
    /// Связь с DescriptionAdvanced — one-to-one (одно описание = одни боевые статы).
    /// </summary>
    public class BattleItemLore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Текст описания (лор кота, эффект бафа, и т.д.).</summary>
        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        /// <summary>Расширенные боевые характеристики (только для Cat Units).</summary>
        public DescriptionAdvanced? DescriptionAdvanced { get; set; }
    }
}