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

        public IEnumerable<SelectedUserSector> GetSelectedUserSectors()
        {
            List<SelectedUserSector> selectedUserSector = (from user in Context.Set<Entities.User>()
                                                           join usersector in Context.Set<Entities.UserSectors>() on user.UserId equals usersector.UserId
                                                           join s in Context.Set<Entities.Sector>() on usersector.SectorId equals s.SectorId
                                                           select new SelectedUserSector
                                                           {
                                                               UserSectorId = usersector.UserSectorId,
                                                               UserName = user.Name,
                                                               SectorName = s.SectorName
                                                           }).ToList();
            return selectedUserSector;
        }
    }
}