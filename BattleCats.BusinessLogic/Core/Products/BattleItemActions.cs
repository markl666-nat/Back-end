using System;
using System.Collections.Generic;
using System.Linq;
using BattleCatsStore.DataAccess.Context;
using BattleCatsStore.Domains.Entities.Products;
using BattleCatsStore.Domains.Enums;
using BattleCatsStore.Domains.Models.Base;
using BattleCatsStore.Domains.Models.Products;

namespace BattleCatsStore.BusinessLogic.Core.BattleItems
{
    public class BattleItemActions
    {
        // Метод загрузки всего инвентаря
        protected List<BattleItemDto> ExecuteLoadAllItems()
        {
            var resultList = new List<BattleItemDto>();
            List<BattleItem> dbItems;

            using (var db = new BattleCatsContext()) // Название контекста под вашу тему
            {
                // Загружаем данные из таблицы
                dbItems = db.Inventory.ToList();
            }

            foreach (var item in dbItems)
            {
                resultList.Add(new BattleItemDto
                {
                    Id = item.InternalId,
                    Name = item.ItemName,
                    Price = item.CatFoodPrice,
                    Rarity = item.RarityTier,
                    // Здесь мы мапим данные из сущности в DTO
                });
            }

            return resultList;
        }

        // Поиск юнита по ID штаба
        protected BattleItemDto? FetchItemDataFromStorage(int id)
        {
            BattleItem? entry;
            using (var db = new BattleCatsContext())
            {
                entry = db.Inventory.FirstOrDefault(x => x.InternalId == id);
            }

            if (entry == null) return null;

            return new BattleItemDto
            {
                Id = entry.InternalId,
                Name = entry.ItemName,
                Price = entry.CatFoodPrice,
                Rarity = entry.RarityTier
            };
        }

        // Обновление характеристик или цены
        protected ActionResponse ExecuteItemUpdateProcess(BattleItemDto itemDto)
        {
            using (var db = new BattleCatsContext())
            {
                var existingEntry = db.Inventory.FirstOrDefault(x => x.InternalId == itemDto.Id);
                if (existingEntry == null)
                {
                    return new ActionResponse { IsSuccess = false, Message = "Unit not found in Cat Army records." };
                }

                // Обновляем поля
                existingEntry.ItemName = itemDto.Name;
                existingEntry.CatFoodPrice = itemDto.Price;
                existingEntry.RarityTier = itemDto.Rarity;
                existingEntry.LastUpdateDate = DateTime.UtcNow;

                db.SaveChanges();
            }

            return new ActionResponse { IsSuccess = true, Message = "Unit data synchronized successfully." };
        }

        // Удаление юнита
        protected ActionResponse ExecuteItemRemoval(int id)
        {
            using (var db = new BattleCatsContext())
            {
                var entryToDelete = db.Inventory.FirstOrDefault(x => x.InternalId == id);
                if (entryToDelete == null)
                {
                    return new ActionResponse { IsSuccess = false, Message = "Target unit does not exist." };
                }

                db.Inventory.Remove(entryToDelete);
                db.SaveChanges();
            }
            return new ActionResponse { IsSuccess = true, Message = "Unit removed from the battlefield." };
        }

        // Создание нового юнита/товара
        protected ActionResponse ExecuteItemCreation(BattleItemDto itemDto)
        {
            using (var db = new BattleCatsContext())
            {
                // Проверка на дубликаты по имени
                var duplicate = db.Inventory.Any(x => x.ItemName.Equals(itemDto.Name));
                if (duplicate)
                {
                    return new ActionResponse
                    {
                        IsSuccess = false,
                        Message = "A unit with this name is already drafted."
                    };
                }

                var newUnit = new BattleItem
                {
                    ItemName = itemDto.Name,
                    CatFoodPrice = itemDto.Price,
                    RarityTier = itemDto.Rarity,
                    StockStatus = ItemAvailability.Available,
                    RecordedDate = DateTime.UtcNow
                };

                db.Inventory.Add(newUnit);
                db.SaveChanges();
            }

            return new ActionResponse { IsSuccess = true, Message = "New unit has been deployed!" };
        }
    }
}