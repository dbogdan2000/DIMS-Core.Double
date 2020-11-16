using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DIMSCoreContext _context;

        private IRepository<UserProfile> _userProfileRepository;

        private IRepository<Direction> _directionRepository;

        private IReadOnlyRepository<VUserProfile> _vUserProfileRepository;

        public IRepository<UserProfile> UserProfileRepository => _userProfileRepository ??= new UserProfileRepository(_context);

        public IRepository<Direction> DirectionRepository => _directionRepository ??= new DirectionRepository(_context);

        public IReadOnlyRepository<VUserProfile> VUserProfileRepository => _vUserProfileRepository ??= new VUserProfileRepository(_context);

        public UnitOfWork(DIMSCoreContext context)
        {
            _context = context;
        }

        #region Disposable
        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion Disposable
    }
}