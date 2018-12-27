using System;
using System.Collections.Generic;
using AutoMapper;
using SectorSelection.Dtos;
using SectorSelection.Repositories.UserSectors;

namespace SectorSelection.Services.UserSectors
{
    public class UserSectorsService : IUserSectorsService
    {
        private readonly IUserSectorsRepository userSectorsRepository;
        private readonly IMapper mapper;

        public UserSectorsService(IUserSectorsRepository userSectorsRepository, IMapper mapper)
        {
            this.userSectorsRepository = userSectorsRepository ?? throw new ArgumentNullException(nameof(userSectorsRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<UserSectorsDto> GetUserSectors()
        {
            var userSectors = userSectorsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UserSectorsDto>>(userSectors);
        }
    }
}