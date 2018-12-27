using SectorSelection.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorSelection.Web.Services.UserSectors
{
    public interface IUserSectorsService
    {
        Task<IEnumerable<UserSectorsDto>> GetUserSectorsAsync();
    }
}