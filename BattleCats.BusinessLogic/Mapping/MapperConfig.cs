using AutoMapper;

namespace BattleCats.BusinessLogic.Mapping
{
    /// <summary>
    /// Статический инициализатор и держатель AutoMapper.
    /// В курсовом не используем DI, поэтому маппер живёт как singleton.
    /// </summary>
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