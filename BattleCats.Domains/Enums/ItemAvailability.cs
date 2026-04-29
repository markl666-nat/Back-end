using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCatsStore.Domains.Enums
{
    public enum ItemAvailability
    {
        Unknown = 0,
        Available = 1,        // Обычная продажа / Доступно
        Hidden = 2,           // Скрыто из каталога (аналог Inactive)
        EventExclusive = 3,   // Доступно только во время ивентов (аналог Discontinued)
        SoldOut = 4           // Распродано (для плюшевых игрушек)
    }
}
