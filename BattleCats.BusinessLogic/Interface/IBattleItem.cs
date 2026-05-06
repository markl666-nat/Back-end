using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Product;

namespace BattleCats.BusinessLogic.Interface
{
    public interface IBattleItem
    {
        List<BattleItemDto> GetAllBattleItemsAction();
        BattleItemDto GetBattleItemByIdAction(int id);
        ActionResponse ResponceBattleItemCreateAction(BattleItemDto item);
        ActionResponse ResponceBattleItemUpdateAction(BattleItemDto item);
        ActionResponse ResponceBattleItemDeleteAction(int id);
    }
}