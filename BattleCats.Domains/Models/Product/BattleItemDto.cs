using BattleCats.Domains.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCatsStore.Domains.Models.Products
{
    public class BattleItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; } // Ссылка на иконку кота (спрайт)
        public bool IsLimitedEdition { get; set; } // Например, для плюшевых игрушек
    }
}