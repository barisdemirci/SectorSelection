using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using SectorSelection.Common;
using SectorSelection.Core.Network;
using SectorSelection.Dtos;
using SectorSelection.Web.Services.UserSectors;
using Xunit;

namespace SectorSelection.Web.Tests.Services
{
    public class UserSectorsServiceTests
    {
        private readonly IUserSectorsService userSectorsService;
        private readonly IHttpClientWrapper httpClient;
        private readonly IConfiguration configuration;

        public UserSectorsServiceTests()
        {
            httpClient = Substitute.For<IHttpClientWrapper>();
            configuration = Substitute.For<IConfiguration>();
            userSectorsService = new UserSectorsService(httpClient, configuration);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new UserSectorsService(null, configuration));
            Assert.Throws<ArgumentNullException>(() => new UserSectorsService(httpClient, null));
        }

        [Fact]
        public async Task GetUserSectorsAsync_CallsApi()
        {
            // arrange
            string endpoint = "endPoint";
            configuration[EndPoints.Api.GetUserSectors].Returns(endpoint);

            // act
            await userSectorsService.GetUserSectorsAsync();

            // asert 
            await httpClient.Received(1).GetAsync<IEnumerable<UserSectorsDto>>(endpoint);
        }
    }
}