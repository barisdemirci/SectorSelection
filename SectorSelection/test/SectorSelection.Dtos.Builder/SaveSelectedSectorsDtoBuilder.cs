using System;
using System.Collections.Generic;

namespace SectorSelection.Dtos.Builder
{
    public static class SaveSelectedSectorsDtoBuilder
    {
        public static SaveSelectedSectorsDto Build(string name = "name", bool agreed = true, List<int> selectedSectors = null)
        {
            return new SaveSelectedSectorsDto()
            {
                Agreed = agreed,
                Name = name,
                SelectedSectors = selectedSectors
            };
        }
    }
}
