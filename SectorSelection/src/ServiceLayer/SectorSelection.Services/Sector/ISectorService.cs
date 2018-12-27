using SectorSelection.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SectorSelection.Services.Sector
{
    public interface ISectorService
    {
        Task<IEnumerable<SectorDto>> GetSectorsAsync();

        Task SaveSelectedSectorsAsync(SaveSelectedSectorsDto selectedSectorsDto);
    }
}