using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorSelection.Dtos;
using SectorSelection.Web.Services.UserSectors;

namespace SectorSelection.Web.Controllers
{
    [Route("usersectors")]
    public class UserSectorsController : Controller
    {
        private readonly IUserSectorsService userSectorsService;

        public UserSectorsController(IUserSectorsService userSectorsService)
        {
            this.userSectorsService = userSectorsService ?? throw new ArgumentNullException(nameof(userSectorsService));
        }

        [HttpGet]
        public async Task<IEnumerable<UserSectorsDto>> GetUserSectorsAsync()
        {
            return await userSectorsService.GetUserSectorsAsync();
        }
    }
}