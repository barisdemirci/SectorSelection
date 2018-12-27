using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Entities
{
    public class SelectedUserSector : BaseEntity
    {
        public int UserSectorId { get; set; }

        public string UserName { get; set; }

        public string SectorName { get; set; }
    }
}