using AutoMapper;

namespace BattleCats.BusinessLogic.Mapping
{
    
    public static class MapperConfig
    {
        private static IMapper? _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<BattleItemMappingProfile>();
                    });
                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }
        }
    }
}