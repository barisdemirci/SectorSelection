using AutoMapper;
using SectorSelection.Dtos;
using SectorSelection.Entities.Sectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Mapper.Profiles
{
    public sealed class SectorProfile : Profile
    {
        public SectorProfile()
        {
            CreateMap<Sector, SectorDto>();
        }
    }
}