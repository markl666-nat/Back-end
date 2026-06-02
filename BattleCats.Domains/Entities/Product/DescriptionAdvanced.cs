using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleCats.Domains.Entities.Product
{
    
    public class DescriptionAdvanced
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int Health { get; set; }

        
        public int Attack { get; set; }

        
        public int Range { get; set; }
    }
}