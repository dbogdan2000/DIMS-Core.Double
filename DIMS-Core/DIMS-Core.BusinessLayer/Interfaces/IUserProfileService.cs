using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    /// <summary>
    ///  TODO: Task #2
    ///  Your next task is change IService interface and Service class to
    ///  generic versions and rewrite your services using them
    /// </summary>

    public interface IUserProfileService
    {
        Task<UserProfileModel> Create(UserProfileModel userProfile);

        Task<UserProfileModel> GetById(int id);

        Task<IEnumerable<UserProfileModel>> GetAll();

        Task<UserProfileModel> Update(UserProfileModel userProfile);

        Task Delete(int id);
    }
}
