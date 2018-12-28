using SectorSelection.Common.Base;
using SectorSelection.Entities;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;
using System.Threading.Tasks;

namespace SectorSelection.Repositories.UnitOfWork
{
    public sealed class UnitOfWork : DisposableObject, IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public ApplicationDbContext Context { get { return context; } }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Sectors = new SectorRepository(context);
            Users = new UserRepository(context);
            UserSectors = new UserSectorsRepository(context);
        }

        public ISectorRepository Sectors
        {
            get; private set;
        }

        public IUserRepository Users
        {
            get;
            private set;
        }

        public IUserSectorsRepository UserSectors
        {
            get; private set;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}