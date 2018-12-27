using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Dtos
{
    public class UserSectorsDto
    {
        public string UserName { get; set; }

        public IEnumerable<SectorDto> Sectors { get; set; }
    }
}