using NSubstitute;
using SectorSelection.Services.UserSectors;
using SectorSelection.WebApi.Controllers;
using System;
using Xunit;

namespace SectorSelection.WebApi.Tests.Controllers
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
        public void GetUserSectorsAsync_CallsService()
        {
            // act
            userSectorsService.GetUserSectors();

            // assert
            userSectorsService.Received(1).GetUserSectors();
        }
    }
}