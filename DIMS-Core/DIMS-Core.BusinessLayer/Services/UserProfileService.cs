using System;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserProfileService : Service, IUserProfileService
    {
        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {
        }

        public async Task<UserProfileModel> Create(UserProfileModel userProfileModel)
        {
            var userProfile = _mapper.Map<UserProfile>(userProfileModel);

            await _unitOfWork.UserProfileRepository.Create(userProfile);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserProfileModel>(userProfile);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.UserProfileRepository.Delete(id);

            await _unitOfWork.SaveAsync();
        }

        public Task<IEquatable<UserProfileModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileModel> update(UserProfileModel userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
