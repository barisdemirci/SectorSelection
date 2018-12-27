using System.Collections.Generic;

namespace SectorSelection.Dtos
{
    public class SaveSelectedSectorsDto
    {
        public string Name { get; set; }

        public bool Agreed { get; set; }

        public List<int> SelectedSectors { get; set; }
    }
}