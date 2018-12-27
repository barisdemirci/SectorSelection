using System.Collections.Generic;
using System.Threading.Tasks;
using SectorSelection.Dtos;

namespace SectorSelection.Services.UserSectors
{
    public interface IUserSectorsService
    {
        IEnumerable<UserSectorsDto> GetUserSectors();
    }
}