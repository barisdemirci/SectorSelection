using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SectorSelection.Entities
{
    public class UserSectors : BaseEntity
    {
        [Key]
        public int UserSectorId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}