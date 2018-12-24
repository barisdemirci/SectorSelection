using AutoMapper;
using SectorSelection.Mapper.Profiles;

namespace SectorSelection.Mapper
{
    public static class AutoMapperFactory
    {
        public static IMapper CreateAndConfigure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SectorProfile>();
            });

            return new AutoMapper.Mapper(config);
        }
    }
}