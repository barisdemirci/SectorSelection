using AutoMapper;
using SectorSelection.Dtos;
using SectorSelection.Entities;

namespace SectorSelection.Mapper.Profiles
{
    public sealed class SectorProfile : Profile
    {
        public SectorProfile()
        {
            CreateMap<Sector, SectorDto>();
            CreateMap<UserSectors, UserSectorsDto>()
                .ForMember(dest => dest.SectorName, options => options.MapFrom(x => x.Sector.SectorName))
                .ForMember(dest => dest.UserName, options => options.MapFrom(x => x.User.Name));
        }
    }
}