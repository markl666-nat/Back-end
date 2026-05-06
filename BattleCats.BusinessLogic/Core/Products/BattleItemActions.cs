using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCats.DataAccess.Context;
using BattleCats.Domains.Entities.Product;
using BattleCats.Domains.Enums;
using BattleCats.Domains.Models.Base;
using BattleCats.Domains.Models.Product;

namespace BattleCats.BusinessLogic.Core.Products
{
    public class BattleItemActions
    {
        protected List<BattleItemDto> ExecuteGetAllBattleItemsAction()
        {
            var items = new List<BattleItemDto>();
            List<BattleItem> bData;

            using (var db = new ProductContext())
            {
                //TODO: Add InerJoin to select on D3 and D4!
                bData = db.BattleItems.ToList();
            }

            foreach (var item in bData)
            {
                var battleItem = new BattleItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Lore = item.Lore,
                    Category = item.Category,
                    Images = item.Images,
                    PriceEuro = item.PriceEuro
                };

                items.Add(battleItem);
            }

            return items;
        }

        protected BattleItemDto GetBattleItemDataByIdAction(int id)
        {
            BattleItem bData;
            using (var db = new ProductContext())
            {
                //TODO: Add InerJoin to select on D3 and D4!
                bData = db.BattleItems.FirstOrDefault(x => x.Id == id);
            }

            return new BattleItemDto()
            {
                Id = bData.Id,
                Name = bData.Name,
                Lore = bData.Lore,
                Category = bData.Category,
                Images = bData.Images,
                PriceEuro = bData.PriceEuro
            };
        }

        protected ActionResponse ExecuteBattleItemUpdateAction(BattleItemDto item)
        {
            using (var db = new ProductContext())
            {
                var bData = db.BattleItems.FirstOrDefault(x => x.Id == item.Id);
                if (bData == null)
                {
                    return new ActionResponse { IsSuccess = false, Message = "Battle item not found." };
                }

                bData.Name = item.Name;
                bData.Lore = item.Lore;
                bData.Category = item.Category;
                bData.Images = item.Images;
                bData.PriceEuro = item.PriceEuro;

                db.SaveChanges();
            }

            return new ActionResponse { IsSuccess = true, Message = "Battle item updated successfully." };
        }

        protected ActionResponse ExecuteBattleItemDeleteAction(int id)
        {
            using (var db = new ProductContext())
            {
                var bData = db.BattleItems.FirstOrDefault(x => x.Id == id);
                if (bData == null)
                {
                    return new ActionResponse { IsSuccess = false, Message = "Battle item not found." };
                }
                db.BattleItems.Remove(bData);
                db.SaveChanges();
            }
            return new ActionResponse { IsSuccess = true, Message = "Battle item deleted successfully." };
        }

        protected ActionResponse ExecuteBattleItemCreateAction(BattleItemDto item)
        {
            BattleItem bData;
            using (var db = new ProductContext())
            {
                bData = db.BattleItems.FirstOrDefault(
                    x => x.Name.Equals(item.Name));
            }

            if (bData != null)
            {
                return new ActionResponse
                {
                    IsSuccess = false,
                    Message = "A battle item with this Name already exist in our system."
                };
            }

            var bLocalData = new BattleItem
            {
                Name = item.Name,
                PriceEuro = item.PriceEuro,
                Lore = item.Lore,
                Category = item.Category,
                Images = item.Images,
                Status = ItemAvailability.Active
            };

            using (var db = new ProductContext())
            {
                db.BattleItems.Add(bLocalData);
                db.SaveChanges();
            }

            return new ActionResponse
            {
                IsSuccess = true,
                Message = "Battle item was succesfully added."
            };
        }
    }
}