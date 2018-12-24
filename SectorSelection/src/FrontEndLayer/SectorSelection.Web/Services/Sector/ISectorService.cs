using SectorSelection.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorSelection.Web.Services.Sector
{
    public interface ISectorService
    {
        Task<IEnumerable<SectorDto>> GetSectorsAsync();
    }
}