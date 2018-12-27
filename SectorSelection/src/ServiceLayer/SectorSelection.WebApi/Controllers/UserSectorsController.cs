using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SectorSelection.Dtos;
using SectorSelection.Services.UserSectors;

namespace SectorSelection.WebApi.Controllers
{
    [Route("rest/v1/usersectors")]
    public class UserSectorsController : Controller
    {
        private readonly IUserSectorsService userSectorsService;

        public UserSectorsController(IUserSectorsService sectorService)
        {
            this.userSectorsService = sectorService ?? throw new ArgumentNullException(nameof(sectorService));
        }

        [HttpGet]
        public IEnumerable<UserSectorsDto> GetUserSectors()
        {
            return userSectorsService.GetUserSectors();
        }
    }
}