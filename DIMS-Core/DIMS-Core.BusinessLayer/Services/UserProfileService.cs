using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserProfileService : Service, IUserProfileService
    {
        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<UserProfileModel>> GetAll()
        {
            var userProfiles = _unitOfWork.UserProfileRepository.GetAll();

            return await _mapper.ProjectTo<UserProfileModel>(userProfiles).ToListAsync();
        }

        public async Task<UserProfileModel> GetById(int id)
        {
            var userProfile = await _unitOfWork.UserProfileRepository.GetById(id);

            return _mapper.Map<UserProfileModel>(userProfile);
        }

        public async Task<UserProfileModel> Update(UserProfileModel userProfile)
        {
            var userProfileEntity = await _unitOfWork.UserProfileRepository.GetById(userProfile.UserId);
            var userProfileUpdatedEntity = await _unitOfWork.UserProfileRepository.Update(_mapper.Map(userProfile, userProfileEntity));

            return _mapper.Map<UserProfileModel>(userProfileUpdatedEntity);
        }

        public async Task<UserProfileModel> Create(UserProfileModel userProfileModel)
        {
            var userProfile = _mapper.Map<UserProfile>(userProfileModel);

            var createdUserEntity = await _unitOfWork.UserProfileRepository.Create(userProfile);

            return _mapper.Map<UserProfileModel>(createdUserEntity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.UserProfileRepository.Delete(id);
        }
    }
}
