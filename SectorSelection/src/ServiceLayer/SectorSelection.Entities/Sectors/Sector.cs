using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SectorSelection.Entities.Sectors
{
    public class Sector : BaseEntity
    {
        [Key]
        public int SectorId { get; set; }

        public int? ParentId { get; set; }

        [MaxLength(255)]
        public string SectorName { get; set; }
    }
}