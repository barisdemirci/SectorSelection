using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SectorSelection.Dtos;
using SectorSelection.Entities;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;

namespace SectorSelection.Services.Sector
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository sectorRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserSectorsRepository userSectorsRepository;
        private readonly IMapper mapper;

        public SectorService(ISectorRepository sectorRepository, IUserRepository userRepository, IUserSectorsRepository userSectorsRepository, IMapper mapper)
        {
            this.sectorRepository = sectorRepository ?? throw new ArgumentNullException(nameof(sectorRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.userSectorsRepository = userSectorsRepository ?? throw new ArgumentNullException(nameof(userSectorsRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SectorDto>> GetSectorsAsync()
        {
            var sectors = await sectorRepository.GetAllAsync();
            return mapper.Map<IEnumerable<SectorDto>>(sectors);
        }

        public async Task SaveSelectedSectorsAsync(SaveSelectedSectorsDto selectedSectorsDto)
        {
            if (selectedSectorsDto == null) throw new ArgumentNullException(nameof(selectedSectorsDto));

            User user = userRepository.GetUserByName(selectedSectorsDto.Name);
            if (user == null)
            {
                await userRepository.AddAsync(new Entities.User()
                {
                    Agreed = selectedSectorsDto.Agreed,
                    Name = selectedSectorsDto.Name
                });
                user = userRepository.GetUserByName(selectedSectorsDto.Name);
            }

            IEnumerable<Entities.UserSectors> userSectors = userSectorsRepository.GetSectorByUserId(user.UserId);
            if (userSectors.Any())
            {
                foreach (var userSector in userSectors)
                {
                    userSectorsRepository.Delete(userSector);
                }
            }

            foreach (var item in selectedSectorsDto.SelectedSectors)
            {
                Entities.Sector sector = sectorRepository.GetSectorByValue(item);
                await userSectorsRepository.AddAsync(new Entities.UserSectors()
                {
                    SectorId = sector.SectorId,
                    UserId = user.UserId
                });
            }
        }
    }
}