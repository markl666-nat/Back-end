using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Product
{
    
    public class BattleItemLore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        
        public DescriptionAdvanced? DescriptionAdvanced { get; set; }
    }
}