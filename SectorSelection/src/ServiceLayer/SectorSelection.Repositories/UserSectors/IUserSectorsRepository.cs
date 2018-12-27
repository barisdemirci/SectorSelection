using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Repositories.UserSectors
{
    public interface IUserSectorsRepository : IRepository<Entities.UserSectors>
    {
        IEnumerable<Entities.UserSectors> GetSectorByUserId(int userId);
    }
}
