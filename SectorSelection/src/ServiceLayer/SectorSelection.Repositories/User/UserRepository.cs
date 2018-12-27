using System.Linq;
using System.Threading.Tasks;
using SectorSelection.Entities;
using SectorSelection.Repositories.User;

namespace SectorSelection.Repositories.User
{
    public class UserRepository : Repository<Entities.User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Entities.User GetUserByName(string name)
        {
            return Context.Set<Entities.User>().FirstOrDefault(x => x.Name == name);
        }
    }
}