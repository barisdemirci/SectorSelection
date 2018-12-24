using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SectorSelection.Dtos;
using SectorSelection.Repositories.Sector;

namespace SectorSelection.Services.Sector
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository sectorRepository;
        private readonly IMapper mapper;

        public SectorService(ISectorRepository sectorRepository, IMapper mapper)
        {
            this.sectorRepository = sectorRepository ?? throw new ArgumentNullException(nameof(sectorRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SectorDto>> GetSectorsAsync()
        {
            var sectors = await sectorRepository.GetSectorsAsync();
            return mapper.Map<IEnumerable<SectorDto>>(sectors);
        }
    }
}