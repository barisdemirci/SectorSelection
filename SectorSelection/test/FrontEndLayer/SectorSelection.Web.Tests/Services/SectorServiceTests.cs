using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using SectorSelection.Common;
using SectorSelection.Core.Network;
using SectorSelection.Dtos;
using SectorSelection.Dtos.Builder;
using SectorSelection.Web.Services.Sector;
using Xunit;

namespace SectorSelection.Web.Tests.Services
{
    public class SectorServiceTests
    {
        private readonly ISectorService sectorService;
        private readonly IHttpClientWrapper httpClient;
        private readonly IConfiguration configuration;

        public SectorServiceTests()
        {
            httpClient = Substitute.For<IHttpClientWrapper>();
            configuration = Substitute.For<IConfiguration>();
            sectorService = new SectorService(httpClient, configuration);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new SectorService(null, configuration));
            Assert.Throws<ArgumentNullException>(() => new SectorService(httpClient, null));
        }

        [Fact]
        public async Task GetSectorsAsync_CallsApiAndCalculateLevel()
        {
            // arrange
            string endpoint = "endPoint";
            configuration[EndPoints.Api.GetSectors].Returns(endpoint);
            List<SectorDto> sectors = new List<SectorDto>()
            {
                SectorDtoBuilder.Build(parent:SectorDtoBuilder.Build(level:1)),
                SectorDtoBuilder.Build(parentId:null),
                SectorDtoBuilder.Build(parentId:null)
            };

            httpClient.GetAsync<IEnumerable<SectorDto>>(endpoint).Returns(sectors);

            // act
            var result = await sectorService.GetSectorsAsync();

            // assert
            await httpClient.Received(1).GetAsync<IEnumerable<SectorDto>>(endpoint);
            result.Count(x => x.ParentId == null && x.Level == 0).Should().Be(2);
        }

        [Fact]
        public async Task SaveSelectedSectorsAsync_CallsApi()
        {
            // arrange
            SaveSelectedSectorsDto dto = SaveSelectedSectorsDtoBuilder.Build();
            string endpoint = "endPoint";
            configuration[EndPoints.Api.SaveSelectedSectors].Returns(endpoint);

            // act
            await sectorService.SaveSelectedSectorsAsync(dto);

            // assert
            await httpClient.PostAsync<SaveSelectedSectorsDto>(endpoint, dto);
        }
    }
}