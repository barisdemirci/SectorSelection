using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using SectorSelection.Dtos;
using SectorSelection.Dtos.Builder;
using SectorSelection.Services.Sector;
using SectorSelection.WebApi.Controllers;
using Xunit;

namespace SectorSelection.WebApi.Tests.Controllers
{
    public class SectorControllerTests
    {
        private readonly SectorController sectorController;
        private readonly ISectorService sectorService;

        public SectorControllerTests()
        {
            sectorService = Substitute.For<ISectorService>();
            sectorController = new SectorController(sectorService);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new SectorController(null));
        }

        [Fact]
        public async Task GetSectorsAsync_CallsService()
        {
            // act
            await sectorController.GetSectorsAsync();

            // assert
            await sectorService.Received(1).GetSectorsAsync();
        }

        [Fact]
        public async Task SaveSelectedSectorsAsync_CallsService()
        {
            // arrange
            SaveSelectedSectorsDto dto = SaveSelectedSectorsDtoBuilder.Build();

            // act
            await sectorController.SaveSelectedSectorsAsync(dto);

            // assert
            await sectorService.Received(1).SaveSelectedSectorsAsync(dto);
        }
    }
}
