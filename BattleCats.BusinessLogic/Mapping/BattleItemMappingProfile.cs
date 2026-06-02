using AutoMapper;
using BattleCats.Domains.Entities.Product;
using BattleCats.Domains.Models.Product;

namespace BattleCats.BusinessLogic.Mapping
{
    
    public class BattleItemMappingProfile : Profile
    {
        public BattleItemMappingProfile()
        {
            
            CreateMap<BattleItem, BattleItemDto>();

            
            CreateMap<BattleItemDto, BattleItem>();
        }
    }
}