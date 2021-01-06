using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserProfileService : IVUserProfileService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        private bool _disposed;

        public VUserProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VUserProfileModel>> GetAll()
        {
            var vUserProfileEntities = _unitOfWork.VUserProfileRepository.GetAll();

            var vUserProfiles = _mapper.ProjectTo<VUserProfileModel>(vUserProfileEntities);

            return await vUserProfiles.ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _unitOfWork.Dispose();

            _disposed = true;
        }
    }
}