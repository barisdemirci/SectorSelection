using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SectorSelection.Dtos;
using SectorSelection.Core.Network;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using SectorSelection.Common;

namespace SectorSelection.Web.Services.Sector
{
    public class SectorService : ISectorService
    {
        private readonly IHttpClientWrapper httpClient;
        private readonly IConfiguration configuration;

        public SectorService(IHttpClientWrapper httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<SectorDto>> GetSectorsAsync()
        {
            string getSectorsUrl = configuration[EndPoints.Api.GetSectors];
            IEnumerable<SectorDto> sectors = await httpClient.GetAsync<IEnumerable<SectorDto>>(getSectorsUrl);
            foreach (var item in sectors)
            {
                item.Level = CalculateLevel(item);
                for (int i = 0; i < item.Level; i++)
                {
                    item.SectorName = item.SectorName.Insert(0, "\xA0\xA0\xA0\xA0\xA0\xA0\xA0\xA0");
                }
            }
            List<SectorDto> orderedList = new List<SectorDto>();
            OrderSectors(sectors.ToList(), orderedList);
            return orderedList;
        }

        public async Task SaveSelectedSectors(SaveSelectedSectorsDto selectedSectorDto)
        {
            string saveSelectedSectorsUrl = configuration[EndPoints.Api.SaveSelectedSectors];
            await httpClient.PostAsync<SaveSelectedSectorsDto>(saveSelectedSectorsUrl, selectedSectorDto);
        }

        private int CalculateLevel(SectorDto sector)
        {
            int level = 0;
            var parent = GetParent(sector, ref level);
            return level;
        }

        private SectorDto GetParent(SectorDto child, ref int level)
        {
            SectorDto parent = child.Parent;
            if (parent == null)
            {
                return parent;
            }
            else
            {
                ++level;
                return GetParent(parent, ref level);
            }
        }

        private void GetChildren(IEnumerable<SectorDto> sectors, List<SectorDto> orderedSectors, SectorDto sector)
        {
            var children = sectors.Where(x => x.ParentId == sector.SectorId).OrderBy(x => x.SectorName).ToList();
            if (children.Any())
            {
                foreach (var item in children)
                {
                    orderedSectors.Add(item);
                    GetChildren(sectors, orderedSectors, item);
                }
            }
        }

        private List<SectorDto> OrderSectors(List<SectorDto> data, List<SectorDto> orderedSectors)
        {
            var parents = data.Where(x => x.ParentId == null);
            foreach (var item in parents)
            {
                orderedSectors.Add(item);
                GetChildren(data, orderedSectors, item);
            }

            return orderedSectors;
        }

        private List<SectorDto> GetSectors(IEnumerable<SectorDto> sectors, int level)
        {
            return sectors.Where(x => x.Level == level).OrderBy(x => x.SectorName).ToList();
        }
    }
}