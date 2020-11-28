using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using System.Linq;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class VUserProfileRepository : IReadOnlyRepository<VUserProfile>
    {
        private DIMSCoreContext _context;

        public VUserProfileRepository(DIMSCoreContext context)
        {
            _context = context;
        }

        public IQueryable<VUserProfile> GetAll() => _context.VUserProfiles;
    }
}