using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Product
{
   
    public class ProductImgData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Required]
        [StringLength(500)]
        public string Url { get; set; } = string.Empty;

        
        public int BattleItemId { get; set; }
    }
}