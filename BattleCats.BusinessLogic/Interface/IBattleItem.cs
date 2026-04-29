using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCatsStore.Domains.Models.Products;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Product;

namespace BattleCatsStore.BusinessLogic.Interface
{
    public interface IBattleItem
    {
        // CRUD: Read (All)
        List<BattleItemDto> GetAllCombatUnits();

        // CRUD: Read (Single)
        BattleItemDto? GetUnitByInternalId(int id);

        // CRUD: Update
        ActionResponse UpdateItemRecord(BattleItemDto item);

        // CRUD: Delete
        ActionResponse RemoveItemFromCatalog(int id);

        // CRUD: Create
        ActionResponse RegisterNewItem(BattleItemDto item);
    }
}
