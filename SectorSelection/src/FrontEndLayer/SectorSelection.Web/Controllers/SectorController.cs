using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorSelection.Dtos;
using SectorSelection.Web.Services.Sector;

namespace SectorSelection.Web.Controllers
{
    [Route("sectors")]
    public class SectorController : Controller
    {
        private readonly ISectorService sectorService;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService ?? throw new ArgumentNullException(nameof(sectorService));
        }

        [HttpGet]
        public async Task<IEnumerable<SectorDto>> GetSectors()
        {
            return await sectorService.GetSectorsAsync();
        }

        [HttpPost]
        public async Task SaveSelectedSectors([FromBody] SaveSelectedSectorsDto selectedSectorsDto)
        {
            await sectorService.SaveSelectedSectors(selectedSectorsDto);
        }
    }
}