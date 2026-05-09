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
using BattleCats.BusinessLogic.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.BusinessLogic.Core.Products
{
    public class BattleItemActions
    {
        /// <summary>
        /// Загружаем товары вместе со всеми связанными сущностями:
        /// Category (для бейджа категории), Lore + DescriptionAdvanced (описание + статы),
        /// Images (картинки). Без Include() EF Core оставляет навигационные свойства null,
        /// и AutoMapper мапит их в null на стороне DTO — отсюда пустые карточки на фронте.
        /// </summary>
        protected List<BattleItemDto> ExecuteGetAllBattleItemsAction()
        {
            List<BattleItem> bData;
            using (var db = new ProductContext())
            {
                bData = db.BattleItems
                    .Include(b => b.Category)
                    .Include(b => b.Lore)
                        .ThenInclude(l => l!.DescriptionAdvanced)
                    .Include(b => b.Images)
                    .ToList();
            }
            return MapperConfig.Mapper.Map<List<BattleItemDto>>(bData);
        }

        protected BattleItemDto GetBattleItemDataByIdAction(int id)
        {
            BattleItem? bData;
            using (var db = new ProductContext())
            {
                bData = db.BattleItems
                    .Include(b => b.Category)
                    .Include(b => b.Lore)
                        .ThenInclude(l => l!.DescriptionAdvanced)
                    .Include(b => b.Images)
                    .FirstOrDefault(x => x.Id == id);
            }

            if (bData == null) return null!;
            return MapperConfig.Mapper.Map<BattleItemDto>(bData);
        }

        protected ActionResponse ExecuteBattleItemUpdateAction(BattleItemDto item)
        {
            using (var db = new ProductContext())
            {
                var bData = db.BattleItems
                    .Include(b => b.Lore)
                    .Include(b => b.Images)
                    .FirstOrDefault(x => x.Id == item.Id);

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
            BattleItem? bData;
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
            var bLocalData = MapperConfig.Mapper.Map<BattleItem>(item);
            bLocalData.Status = ItemAvailability.Active;
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