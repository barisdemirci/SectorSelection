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

            //Manufacturing
            sectors.Add(BuildSector("Construction materials", 1, 19));

            // Construction materials
            sectors.Add(BuildSector("Electronics and Optics", 19, 18));
            sectors.Add(BuildSector("Food and Beverage", 19, 6));
            sectors.Add(BuildSector("Furniture", 19, 13));
            sectors.Add(BuildSector("Machinery", 19, 12));
            sectors.Add(BuildSector("Metalworking", 19, 11));
            sectors.Add(BuildSector("Plastic and Rubber", 19, 9));
            sectors.Add(BuildSector("Printing", 19, 5));
            sectors.Add(BuildSector("Textile and Clothing", 19, 7));
            sectors.Add(BuildSector("Wood", 19, 8));

            // Food and Beverage
            sectors.Add(BuildSector("Milk & dairy products", 6, 39));
            sectors.Add(BuildSector("Meat & meat products", 6, 40));
            sectors.Add(BuildSector("Fish & fish products", 6, 42));
            sectors.Add(BuildSector("Bakery & confectionery products", 6, 342));
            sectors.Add(BuildSector("Beverages", 6, 43));
            sectors.Add(BuildSector("Other", 6, 437));
            sectors.Add(BuildSector("Sweets & snack food", 6, 378));

            // Furniture
            sectors.Add(BuildSector("Bathroom/sauna", 13, 389));
            sectors.Add(BuildSector("Bedroom", 13, 385));
            sectors.Add(BuildSector("Children’s room", 13, 390));
            sectors.Add(BuildSector("Kitchen ", 13, 98));
            sectors.Add(BuildSector("Living room", 13, 101));
            sectors.Add(BuildSector("Office", 13, 392));
            sectors.Add(BuildSector("Other (Furniture)", 13, 394));
            sectors.Add(BuildSector("Outdoor", 13, 341));
            sectors.Add(BuildSector("Project furniture", 13, 99));

            // Machinery
            sectors.Add(BuildSector("Machinery components", 12, 94));
            sectors.Add(BuildSector("Machinery equipment/tools", 12, 91));
            sectors.Add(BuildSector("Manufacture of machinery", 12, 224));
            sectors.Add(BuildSector("Maritime", 12, 97));
            sectors.Add(BuildSector("Metal structures", 12, 93));
            sectors.Add(BuildSector("Other", 12, 508));
            sectors.Add(BuildSector("Repair and maintenance service", 12, 227));

            // Maritime
            sectors.Add(BuildSector("Aluminium and steel workboats", 97, 271));
            sectors.Add(BuildSector("Boat/Yacht building", 97, 269));
            sectors.Add(BuildSector("Ship repair and conversion", 97, 230));

            // Metalworking
            sectors.Add(BuildSector("Construction of metal structures", 11, 67));
            sectors.Add(BuildSector("Houses and buildings", 11, 263));
            sectors.Add(BuildSector("Metal products", 11, 267));
            sectors.Add(BuildSector("Metal works", 11, 542));

            // Metal works
            sectors.Add(BuildSector("CNC-machining", 542, 75));
            sectors.Add(BuildSector("Forgings, Fasteners", 542, 62));
            sectors.Add(BuildSector("Gas, Plasma, Laser cutting", 542, 69));
            sectors.Add(BuildSector("MIG, TIG, Aluminum welding", 542, 66));

            // Plastic and Rubber
            sectors.Add(BuildSector("Packaging", 9, 54));
            sectors.Add(BuildSector("Plastic goods", 9, 556));
            sectors.Add(BuildSector("Plastic processing technology", 9, 559));
            sectors.Add(BuildSector("Plastic profiles", 9, 560));

            // Plastic processing technology
            sectors.Add(BuildSector("Blowing", 559, 55));
            sectors.Add(BuildSector("Moulding", 559, 57));
            sectors.Add(BuildSector("Plastics welding and processing", 559, 53));

            // Printing
            sectors.Add(BuildSector("Advertising", 5, 148));
            sectors.Add(BuildSector("Book/Periodicals printing", 5, 150));
            sectors.Add(BuildSector("Labelling and packaging printing", 5, 145));

            // Textile and Clothing
            sectors.Add(BuildSector("Clothing", 7, 44));
            sectors.Add(BuildSector("Textile", 7, 45));

            // Wood
            sectors.Add(BuildSector("Other (Wood)", 8, 337));
            sectors.Add(BuildSector("Wooden building materials", 8, 51));
            sectors.Add(BuildSector("Wooden houses", 8, 47));

            // Other
            sectors.Add(BuildSector("Creative industries", 3, 37));
            sectors.Add(BuildSector("Energy technology", 3, 29));
            sectors.Add(BuildSector("Environment", 3, 33));

            // Service
            sectors.Add(BuildSector("Business services", 2, 25));
            sectors.Add(BuildSector("Engineering", 2, 35));
            sectors.Add(BuildSector("Information Technology and Telecommunications", 2, 28));
            sectors.Add(BuildSector("Tourism", 2, 22));
            sectors.Add(BuildSector("Translation services", 2, 141));
            sectors.Add(BuildSector("Transport and Logistics", 2, 21));

            // Information Technology and Telecommunications
            sectors.Add(BuildSector("Data processing, Web portals, E-marketing", 28, 581));
            sectors.Add(BuildSector("Programming, Consultancy", 28, 576));
            sectors.Add(BuildSector("Software, Hardware", 28, 121));
            sectors.Add(BuildSector("Telecommunications", 28, 122));

            // Transport and Logistics
            sectors.Add(BuildSector("Air", 21, 111));
            sectors.Add(BuildSector("Rail", 21, 114));
            sectors.Add(BuildSector("Road", 21, 112));
            sectors.Add(BuildSector("Water", 21, 113));
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