using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SectorSelection.Entities.Sectors
{
    public class Sector : BaseEntity
    {
        [Key]
        public int SectorId { get; set; }

        [Required]
        public int Value { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SectorName { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [ForeignKey("ParentId")]
        public virtual Sector Parent { get; set; }
    }
}