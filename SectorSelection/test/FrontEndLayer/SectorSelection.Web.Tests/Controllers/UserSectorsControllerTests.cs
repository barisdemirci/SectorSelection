using System;
using System.Threading.Tasks;
using NSubstitute;
using SectorSelection.Web.Controllers;
using SectorSelection.Web.Services.UserSectors;
using Xunit;

namespace SectorSelection.Web.Tests.Controllers
{
    public class UserSectorsControllerTests
    {
        private readonly UserSectorsController userSectorsController;
        private readonly IUserSectorsService userSectorsService;

        public UserSectorsControllerTests()
        {
            userSectorsService = Substitute.For<IUserSectorsService>();
            userSectorsController = new UserSectorsController(userSectorsService);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new UserSectorsController(null));
        }

        [Fact]
        public async Task GetUserSectorsAsync_CallsService()
        {
            // act
            await userSectorsService.GetUserSectorsAsync();

            // assert
            await userSectorsService.Received(1).GetUserSectorsAsync();
        }
    }
}