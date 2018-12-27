using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SectorSelection.Common;
using SectorSelection.Core.Network;
using SectorSelection.Dtos;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace SectorSelection.Web.Services.UserSectors
{
    public class UserSectorsService : IUserSectorsService
    {
        private readonly IHttpClientWrapper httpClient;
        private readonly IConfiguration configuration;

        public UserSectorsService(IHttpClientWrapper httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<UserSectorsDto>> GetUserSectorsAsync()
        {
            string getSectorsUrl = configuration[EndPoints.Api.GetUserSectors];
            return await httpClient.GetAsync<IEnumerable<UserSectorsDto>>(getSectorsUrl);
        }
    }
}