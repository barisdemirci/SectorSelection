using Microsoft.EntityFrameworkCore;
using SectorSelection.Entities.Sectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SectorSelection.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Helmes;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Sector> Sectors { get; set; }
    }
}
