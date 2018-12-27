using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NSubstitute;
using SectorSelection.Mapper.Profiles;
using SectorSelection.Repositories.UserSectors;
using SectorSelection.Services.UserSectors;
using Xunit;

namespace SectorSelection.Services.Tests.UserSectors
{
    public class UserSectorsServiceTests
    {
        private readonly IUserSectorsService userSectorsService;
        private readonly IUserSectorsRepository userSectorsRepository;
        private readonly IMapper mapper;

        public UserSectorsServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SectorProfile>();
            });

            mapper = new AutoMapper.Mapper(config);
            userSectorsRepository = Substitute.For<IUserSectorsRepository>();

            userSectorsService = new UserSectorsService(userSectorsRepository, mapper);
        }

        [Fact]
        public void Constructor_ArgumentIsNull_ThrowsArgumentNullException()
        {
            // act & assert
            Assert.Throws<ArgumentNullException>(() => new UserSectorsService(null, mapper));
            Assert.Throws<ArgumentNullException>(() => new UserSectorsService(userSectorsRepository, null));
        }

        [Fact]
        public void GetUserSectors_CallsRepository()
        {
            // act
            userSectorsService.GetUserSectors();

            // assert
            userSectorsRepository.Received(1).GetSelectedUserSectors();
        }
    }
}