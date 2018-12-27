using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorSelection.Dtos;
using SectorSelection.Web.Services.UserSectors;

namespace SectorSelection.Web.Controllers
{
    public class UserSectorsController : Controller
    {
        private readonly IUserSectorsService userSectorsService;

        public UserSectorsController(IUserSectorsService sectorService)
        {
            this.userSectorsService = sectorService ?? throw new ArgumentNullException(nameof(sectorService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<UserSectorsDto>> GetUserSectorsAsync()
        {
            return await userSectorsService.GetUserSectorsAsync();
        }
    }
}