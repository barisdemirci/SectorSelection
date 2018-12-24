using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SectorSelection.Dtos;
using SectorSelection.Services.Sector;

namespace SectorSelection.WebApi.Controllers
{
    [Route("rest/v1/sector")]
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
    }
}