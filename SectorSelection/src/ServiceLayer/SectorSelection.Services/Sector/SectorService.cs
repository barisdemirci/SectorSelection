using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SectorSelection.Dtos;
using SectorSelection.Entities;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.UnitOfWork;

namespace SectorSelection.Services.Sector
{
    public class SectorService : ISectorService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SectorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SectorDto>> GetSectorsAsync()
        {
            var sectors = await unitOfWork.Sectors.GetAllAsync();
            return mapper.Map<IEnumerable<SectorDto>>(sectors);
        }

        public async Task SaveSelectedSectorsAsync(SaveSelectedSectorsDto selectedSectorsDto)
        {
            if (selectedSectorsDto == null) throw new ArgumentNullException(nameof(selectedSectorsDto));

            User user = unitOfWork.Users.GetUserByName(selectedSectorsDto.Name);
            if (user == null)
            {
                user = new User()
                {
                    Agreed = selectedSectorsDto.Agreed,
                    Name = selectedSectorsDto.Name
                };
                await unitOfWork.Users.AddAsync(user);
                await unitOfWork.SaveAsync();
            }

            IEnumerable<Entities.UserSectors> userSectors = unitOfWork.UserSectors.GetSectorByUserId(user.UserId);
            if (userSectors.Any())
            {
                foreach (var userSector in userSectors)
                {
                    unitOfWork.UserSectors.Delete(userSector);
                }
            }

            foreach (var item in selectedSectorsDto.SelectedSectors)
            {
                Entities.Sector sector = unitOfWork.Sectors.GetSectorByValue(item);
                await unitOfWork.UserSectors.AddAsync(new Entities.UserSectors()
                {
                    SectorId = sector.SectorId,
                    UserId = user.UserId
                });
            }
            await unitOfWork.SaveAsync();
        }
    }
}