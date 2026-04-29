using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCatsStore.Domains.Entities.Refs
{
    public abstract class BaseStoreEntity
    {
        // Дата появления кота/товара в архиве
        public DateTime RecordedDate { get; set; } = DateTime.UtcNow;
        // Последнее изменение характеристик или цены
        public DateTime? LastUpdateDate { get; set; }
    }
}