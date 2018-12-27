using System;
using System.Collections.Generic;
using System.Linq;
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
            var userSectors = userSectorsRepository.GetSelectedUserSectors();
            var grouppedList = userSectors.GroupBy(x => x.UserName);
            List<UserSectorsDto> list = new List<UserSectorsDto>();
            foreach (var item in grouppedList)
            {
                list.Add(new UserSectorsDto()
                {
                    UserName = item.Key,
                    Sectors = item.Select(x => new SectorDto { SectorName = x.SectorName }),
                });
            }
            return list;
        }
    }
}