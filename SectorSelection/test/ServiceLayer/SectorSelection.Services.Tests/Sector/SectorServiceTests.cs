using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NSubstitute;
using SectorSelection.Dtos;
using SectorSelection.Dtos.Builder;
using SectorSelection.Entities;
using SectorSelection.Mapper.Profiles;
using SectorSelection.Repositories.UnitOfWork;
using SectorSelection.Services.Sector;
using Xunit;

namespace SectorSelection.Services.Tests.Sector
{
    public class SectorServiceTests
    {
        private readonly ISectorService sectorService;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SectorServiceTests()
        {
            unitOfWork = Substitute.For<IUnitOfWork>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SectorProfile>();
            });

            mapper = new AutoMapper.Mapper(config);
            sectorService = new SectorService(unitOfWork, mapper);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new SectorService(null, mapper));
            Assert.Throws<ArgumentNullException>(() => new SectorService(unitOfWork, null));
        }

        [Fact]
        public async Task GetSectorsAsync_CallsRepository()
        {
            // act
            await sectorService.GetSectorsAsync();

            // assert
            await unitOfWork.Sectors.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task SaveSelectedSectorsAsync_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sectorService.SaveSelectedSectorsAsync(null));
        }

        [Fact]
        public async Task SaveSelectedSectorsAsync_UserExists_CallsUserSectorsRepository()
        {
            // arrange
            SaveSelectedSectorsDto dto = SaveSelectedSectorsDtoBuilder.Build();
            dto.SelectedSectors = new List<int>()
            {
                1, 2, 3
            };
            User user = new User()
            {
                Agreed = true,
                Name = "Name",
                UserId = 1
            };
            unitOfWork.Users.GetUserByName(dto.Name).Returns(user);
            List<Entities.UserSectors> userSectors = new List<Entities.UserSectors>()
            {
                new Entities.UserSectors()
                {
                    SectorId = 1,
                    UserId =1
                }
            };
            unitOfWork.UserSectors.GetSectorByUserId(user.UserId).Returns(userSectors);
            unitOfWork.Sectors.GetSectorByValue(Arg.Any<int>()).Returns(new Entities.Sector() { });

            // act
            await sectorService.SaveSelectedSectorsAsync(dto);

            // assert
            await unitOfWork.Users.DidNotReceive().AddAsync(Arg.Any<User>());
            unitOfWork.UserSectors.Received(1).Delete(Arg.Any<Entities.UserSectors>());
            await unitOfWork.UserSectors.Received(3).AddAsync(Arg.Any<Entities.UserSectors>());
        }

        [Fact]
        public async Task SaveSelectedSectorsAsync_NoUserSectors_DontCallUserSectorsRepositoryDelete()
        {
            // arrange
            SaveSelectedSectorsDto dto = SaveSelectedSectorsDtoBuilder.Build();
            dto.SelectedSectors = new List<int>()
            {
                1, 2, 3
            };
            User user = new User()
            {
                Agreed = true,
                Name = "Name",
                UserId = 1
            };
            unitOfWork.Users.GetUserByName(dto.Name).Returns(user);
            List<Entities.UserSectors> userSectors = new List<Entities.UserSectors>();
            unitOfWork.UserSectors.GetSectorByUserId(Arg.Any<int>()).Returns(userSectors);
            unitOfWork.Sectors.GetSectorByValue(Arg.Any<int>()).Returns(new Entities.Sector() { });

            // act
            await sectorService.SaveSelectedSectorsAsync(dto);

            // assert
            unitOfWork.UserSectors.DidNotReceive().Delete(Arg.Any<Entities.UserSectors>());
        }
    }
}