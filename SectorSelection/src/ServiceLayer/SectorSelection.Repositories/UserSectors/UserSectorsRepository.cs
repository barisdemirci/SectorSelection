using System.Collections.Generic;
using System.Linq;
using SectorSelection.Entities;

namespace SectorSelection.Repositories.UserSectors
{
    public class UserSectorsRepository : Repository<Entities.UserSectors>, IUserSectorsRepository
    {
        public UserSectorsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Entities.UserSectors> GetSectorByUserId(int userId)
        {
            return Context.Set<Entities.UserSectors>().Where(x => x.UserId == userId).ToList();
        }
    }
}