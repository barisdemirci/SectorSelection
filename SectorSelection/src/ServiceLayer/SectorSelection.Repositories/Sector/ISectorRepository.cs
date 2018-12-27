using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SectorSelection.Repositories.Sector
{
    public interface ISectorRepository : IRepository<Entities.Sector>
    {
        Entities.Sector GetSectorByValue(int value);
    }
}