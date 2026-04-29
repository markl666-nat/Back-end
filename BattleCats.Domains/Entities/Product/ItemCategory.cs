using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCatsStore.Domains.Entities.Products
{
    public class ItemCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } // Сменили Id на CategoryId

        public string Title { get; set; } // Сменили Name на Title (например: "Normal Cats", "Uber Rare", "Plushies")
    }
}
