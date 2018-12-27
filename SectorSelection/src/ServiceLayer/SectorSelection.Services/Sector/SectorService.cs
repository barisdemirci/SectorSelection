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
        private readonly ISectorRepository sectorRepository;
        private readonly IMapper mapper;

        public SectorService(ISectorRepository sectorRepository, IMapper mapper)
        {
            this.sectorRepository = sectorRepository ?? throw new ArgumentNullException(nameof(sectorRepository));
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
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    User user = unitOfWork.UserRepository.GetUserByName(selectedSectorsDto.Name);
                    if (user == null)
                    {
                        await unitOfWork.UserRepository.AddAsync(new Entities.User()
                        {
                            Agreed = selectedSectorsDto.Agreed,
                            Name = selectedSectorsDto.Name
                        });
                        user = unitOfWork.Context.Users.Local.First(x => x.Name == selectedSectorsDto.Name);
                    }

                    IEnumerable<Entities.UserSectors> userSectors = unitOfWork.UserSectorsRepository.GetSectorByUserId(user.UserId);
                    if (userSectors.Any())
                    {
                        foreach (var userSector in userSectors)
                        {
                            unitOfWork.UserSectorsRepository.Delete(userSector);
                        }
                    }

                    foreach (var item in selectedSectorsDto.SelectedSectors)
                    {
                        Entities.Sector sector = unitOfWork.SectorRepository.GetSectorByValue(item);
                        await unitOfWork.UserSectorsRepository.AddAsync(new Entities.UserSectors()
                        {
                            SectorId = sector.SectorId,
                            UserId = user.UserId
                        });
                    }

                    unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

            }
        }
    }
}