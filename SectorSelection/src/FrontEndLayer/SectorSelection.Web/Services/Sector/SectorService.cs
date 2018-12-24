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
            string batchJobUri = configuration[EndPoints.Api.GetSectors];
            return await httpClient.GetAsync<IEnumerable<SectorDto>>(batchJobUri);
        }
    }
}