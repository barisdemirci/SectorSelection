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
            CreateMap<SelectedUserSector, UserSectorsDto>();
        }
    }
}