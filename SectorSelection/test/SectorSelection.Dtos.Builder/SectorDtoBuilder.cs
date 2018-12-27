using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Dtos.Builder
{
    public static class SectorDtoBuilder
    {
        public static SectorDto Build(string sectorName = "sector", int value = 1, int level = 1, int? parentId = null, int sectorId = 1, SectorDto parent = null, bool isActive = true)
        {
            return new SectorDto()
            {
                IsActive = isActive,
                Level = level,
                Parent = parent,
                ParentId = parentId,
                SectorId = sectorId,
                SectorName = sectorName,
                Value = value
            };
        }
    }
}