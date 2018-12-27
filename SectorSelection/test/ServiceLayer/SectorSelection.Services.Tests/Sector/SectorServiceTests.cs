using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NSubstitute;
using SectorSelection.Dtos;
using SectorSelection.Dtos.Builder;
using SectorSelection.Entities;
using SectorSelection.Mapper.Profiles;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;
using SectorSelection.Services.Sector;
using Xunit;

namespace SectorSelection.Services.Tests.Sector
{
    public class SectorServiceTests
    {
        private readonly ISectorService sectorService;
        private readonly ISectorRepository sectorRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserSectorsRepository userSectorsRepository;
        private readonly IMapper mapper;

        public SectorServiceTests()
        {
            sectorRepository = Substitute.For<ISectorRepository>();
            userRepository = Substitute.For<IUserRepository>();
            userSectorsRepository = Substitute.For<IUserSectorsRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SectorProfile>();
            });

            mapper = new AutoMapper.Mapper(config);
            sectorService = new SectorService(sectorRepository, userRepository, userSectorsRepository, mapper);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new SectorService(null, userRepository, userSectorsRepository, mapper));
            Assert.Throws<ArgumentNullException>(() => new SectorService(sectorRepository, null, userSectorsRepository, mapper));
            Assert.Throws<ArgumentNullException>(() => new SectorService(sectorRepository, userRepository, null, mapper));
            Assert.Throws<ArgumentNullException>(() => new SectorService(sectorRepository, userRepository, userSectorsRepository, null));
        }

        [Fact]
        public async Task GetSectorsAsync_CallsRepository()
        {
            // act
            await sectorService.GetSectorsAsync();

            // assert
            await sectorRepository.Received(1).GetAllAsync();
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
            userRepository.GetUserByName(dto.Name).Returns(user);
            List<Entities.UserSectors> userSectors = new List<Entities.UserSectors>()
            {
                new Entities.UserSectors()
                {
                    SectorId = 1,
                    UserId =1
                }
            };
            userSectorsRepository.GetSectorByUserId(user.UserId).Returns(userSectors);
            sectorRepository.GetSectorByValue(Arg.Any<int>()).Returns(new Entities.Sector() { });

            // act
            await sectorService.SaveSelectedSectorsAsync(dto);

            // assert
            await userRepository.DidNotReceive().AddAsync(Arg.Any<User>());
            userSectorsRepository.Received(1).Delete(Arg.Any<Entities.UserSectors>());
            await userSectorsRepository.Received(3).AddAsync(Arg.Any<Entities.UserSectors>());
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
            userRepository.GetUserByName(dto.Name).Returns(user);
            List<Entities.UserSectors> userSectors = new List<Entities.UserSectors>();
            userSectorsRepository.GetSectorByUserId(Arg.Any<int>()).Returns(userSectors);
            sectorRepository.GetSectorByValue(Arg.Any<int>()).Returns(new Entities.Sector() { });

            // act
            await sectorService.SaveSelectedSectorsAsync(dto);

            // assert
            userSectorsRepository.DidNotReceive().Delete(Arg.Any<Entities.UserSectors>());
        }
    }
}