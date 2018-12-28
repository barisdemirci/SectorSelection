using System.Threading.Tasks;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;

namespace SectorSelection.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISectorRepository Sectors { get; }
        IUserRepository Users { get; }
        IUserSectorsRepository UserSectors { get; }

        Task SaveAsync();
    }
}