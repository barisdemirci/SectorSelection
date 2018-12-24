using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectorSelection.Entities;
using SectorSelection.Entities.Sectors;

namespace SectorSelection.Repositories.Sector
{
    public class SectorRepository : Repository<Entities.Sectors.Sector>, ISectorRepository
    {
        public SectorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Entities.Sectors.Sector>> GetSectorsAsync()
        {
            return await GetAllAsync();
        }
    }
}