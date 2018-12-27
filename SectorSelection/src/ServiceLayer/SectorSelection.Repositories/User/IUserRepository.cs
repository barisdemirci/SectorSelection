using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SectorSelection.Repositories.User
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Entities.User GetUserByName(string name);
    }
}