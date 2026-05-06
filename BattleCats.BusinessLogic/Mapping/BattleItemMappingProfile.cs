using AutoMapper;
using BattleCats.Domains.Entities.Product;
using BattleCats.Domains.Models.Product;

namespace BattleCats.BusinessLogic.Mapping
{
    /// <summary>
    /// Профиль AutoMapper для конвертации между Entity (BattleItem) и DTO (BattleItemDto).
    /// Используется в BattleItemActions вместо ручного маппинга.
    /// </summary>
    public class BattleItemMappingProfile : Profile
    {
        public BattleItemMappingProfile()
        {
            // Entity -> DTO (для чтения из БД)
            CreateMap<BattleItem, BattleItemDto>();

            // DTO -> Entity (для записи в БД)
            CreateMap<BattleItemDto, BattleItem>();
        }
    }
}