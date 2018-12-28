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
        public ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return Context as ApplicationDbContext;
            }
        }

        public SectorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Entities.Sector GetSectorByValue(int value)
        {
            return ApplicationDbContext.Set<Entities.Sector>().FirstOrDefault(x => x.Value == value);
        }
    }
}