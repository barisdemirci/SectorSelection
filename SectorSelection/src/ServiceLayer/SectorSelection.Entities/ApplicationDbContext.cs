using Microsoft.EntityFrameworkCore;

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

        public DbSet<User> Users { get; set; }

        public DbSet<UserSectors> UserSectors { get; set; }
    }
}
