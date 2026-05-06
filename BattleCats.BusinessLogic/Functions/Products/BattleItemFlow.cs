using BattleCats.BusinessLogic.Core.Products;
using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Product;

namespace BattleCats.BusinessLogic.Functions.Products
{
    public class BattleItemFlow : BattleItemActions, IBattleItem
    {
        public List<BattleItemDto> GetAllBattleItemsAction()
        {
            var items = ExecuteGetAllBattleItemsAction();
            return items;
        }

        public BattleItemDto GetBattleItemByIdAction(int id)
        {
            return GetBattleItemDataByIdAction(id);
        }

        public ActionResponse ResponceBattleItemUpdateAction(BattleItemDto item)
        {
            return ExecuteBattleItemUpdateAction(item);
        }

        public ActionResponse ResponceBattleItemDeleteAction(int id)
        {
            return ExecuteBattleItemDeleteAction(id);
        }

        public ActionResponse ResponceBattleItemCreateAction(BattleItemDto item)
        {
            return ExecuteBattleItemCreateAction(item);
        }
    }
}