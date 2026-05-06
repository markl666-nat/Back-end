using System.Collections.Generic;
using BattleCatsStore.BusinessLogic.Core.BattleItems;
using BattleCatsStore.BusinessLogic.Interface;
using BattleCatsStore.Domains.Entities.Products;
using BattleCatsStore.Domains.Models.Base;
using BattleCatsStore.Domains.Models.Products;

namespace BattleCatsStore.BusinessLogic.Services.BattleItems
{
    // Вместо ProductFlow используем BattleItemService
    // Наследуемся от BattleItemLogic (бывший ProductAction)
    public class BattleItemService : BattleItemActions, IBattleItem
    {
        // Получение всех боевых единиц (Котов, Баффов, Мерча)
        public List<BattleItemDto> GetAllCombatUnits()
        {
            // Вызываем внутреннюю логику обработки из базового класса
            var inventory = ExecuteLoadAllItems();
            return inventory;
        }

        // Поиск конкретного юнита по ID
        public BattleItemDto? GetUnitByInternalId(int id)
        {
            return FetchItemDataFromStorage(id);
        }

        // Обновление данных (например, изменение цены в Кетфуде)
        public ActionResponse UpdateItemRecord(BattleItemDto item)
        {
            return ExecuteItemUpdateProcess(item);
        }

        // Удаление (архивация) юнита из магазина
        public ActionResponse RemoveItemFromCatalog(int id)
        {
            return ExecuteItemRemoval(id);
        }

        // Регистрация нового юнита или товара
        public ActionResponse RegisterNewItem(BattleItemDto item)
        {
            return ExecuteItemCreation(item);
        }
    }
}