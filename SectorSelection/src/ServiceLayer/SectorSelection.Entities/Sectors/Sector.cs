using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Entities.Sectors
{
    public class Sector : BaseEntity
    {
        public int SectorId { get; set; }

        public int ParentId { get; set; }

        public string SectorName { get; set; }
    }
}