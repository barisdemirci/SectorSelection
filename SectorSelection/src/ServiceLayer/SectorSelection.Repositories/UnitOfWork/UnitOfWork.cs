using SectorSelection.Common.Base;
using SectorSelection.Entities;
using SectorSelection.Repositories.Sector;
using SectorSelection.Repositories.User;
using SectorSelection.Repositories.UserSectors;

namespace SectorSelection.Repositories.UnitOfWork
{
    public sealed class UnitOfWork : DisposableObject
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private SectorRepository sectorRepository;
        private UserRepository userRepository;
        private UserSectorsRepository userSectorsRepository;

        public ApplicationDbContext Context { get { return context; } }

        public SectorRepository SectorRepository
        {
            get
            {

                if (this.sectorRepository == null)
                {
                    this.sectorRepository = new SectorRepository(context);
                }
                return sectorRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public UserSectorsRepository UserSectorsRepository
        {
            get
            {

                if (this.userSectorsRepository == null)
                {
                    this.userSectorsRepository = new UserSectorsRepository(context);
                }
                return userSectorsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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