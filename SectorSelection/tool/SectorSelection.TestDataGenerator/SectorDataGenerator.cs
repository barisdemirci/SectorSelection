using SectorSelection.Dtos;
using System;
using System.Collections.Generic;

namespace SectorSelection.TestDataGenerator
{
    public static class SectorDataGenerator
    {
        public static List<SectorDto> GenerateSectors()
        {
            List<SectorDto> sectors = new List<SectorDto>();
            sectors.Add(BuildSector("Manufacturing", null, 1));
            sectors.Add(BuildSector("Service", null, 2));
            sectors.Add(BuildSector("Other", null, 3));
            sectors.Add(BuildSector("Printing", 1, 5));
            sectors.Add(BuildSector("Food and Beverage", 1, 6));
            sectors.Add(BuildSector("Textile and Clothing", 1, 7));
            sectors.Add(BuildSector("Wood", 1, 8));
            sectors.Add(BuildSector("Plastic and Rubber", 1, 9));
            sectors.Add(BuildSector("Metalworking", 1, 11));
            sectors.Add(BuildSector("Machinery", 1, 12));
            sectors.Add(BuildSector("Furniture", 1, 13));
            sectors.Add(BuildSector("Electronics and Optics", 1, 18));
            sectors.Add(BuildSector("Construction materials", 1, 19));
            sectors.Add(BuildSector("Transport and Logistics", 2, 21));
            sectors.Add(BuildSector("Tourism", 2, 22));
            sectors.Add(BuildSector("Business services", 2, 25));
            sectors.Add(BuildSector("Information Technology and Telecommunications", 2, 28));
            sectors.Add(BuildSector("Energy technology", 2, 29));
            sectors.Add(BuildSector("Environment", 3, 33));
            sectors.Add(BuildSector("Engineering", 2, 35));
            sectors.Add(BuildSector("Creative industries", 3, 37));
            sectors.Add(BuildSector("Milk & dairy products", 6, 39));
            return sectors;
        }

        private static SectorDto BuildSector(string sectorName, int? parentId, int value)
        {
            return new SectorDto()
            {
                IsActive = true,
                SectorName = sectorName,
                ParentId = parentId,
                Value = value
            };
        }
    }
}