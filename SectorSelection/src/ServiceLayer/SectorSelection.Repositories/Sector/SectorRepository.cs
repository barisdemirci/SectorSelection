using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectorSelection.Entities;

namespace SectorSelection.Repositories.Sector
{
    public class SectorRepository : Repository<Entities.Sector>, ISectorRepository
    {
        public SectorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Entities.Sector GetSectorByValue(int value)
        {
            return Context.Set<Entities.Sector>().FirstOrDefault(x => x.Value == value);
        }
    }
}