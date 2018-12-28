using System.Linq;
using System.Threading.Tasks;
using SectorSelection.Entities;
using SectorSelection.Repositories.User;

namespace SectorSelection.Repositories.User
{
    public class UserRepository : Repository<Entities.User>, IUserRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return Context as ApplicationDbContext;
            }
        }

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Entities.User GetUserByName(string name)
        {
            return ApplicationDbContext.Set<Entities.User>().FirstOrDefault(x => x.Name == name);
        }
    }
}