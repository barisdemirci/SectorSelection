using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SectorSelection.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public bool Agreed { get; set; }
    }
}