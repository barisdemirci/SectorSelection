using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SectorSelection.Entities.Sectors;

namespace SectorSelection.Repositories.Sector
{
    public interface ISectorRepository
    {
        Task<IEnumerable<Entities.Sectors.Sector>> GetSectorsAsync();
    }
}