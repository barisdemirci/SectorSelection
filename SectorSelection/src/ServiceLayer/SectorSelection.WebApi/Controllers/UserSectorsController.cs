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

        public UserSectorsController(IUserSectorsService userSectorsService)
        {
            this.userSectorsService = userSectorsService ?? throw new ArgumentNullException(nameof(userSectorsService));
        }

        [HttpGet]
        public IEnumerable<UserSectorsDto> GetUserSectors()
        {
            return userSectorsService.GetUserSectors();
        }
    }
}