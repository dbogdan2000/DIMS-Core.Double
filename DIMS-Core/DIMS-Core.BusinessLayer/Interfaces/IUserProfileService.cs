using System;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.MappingProfiles;
using DIMS_Core.BusinessLayer.Models;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    /// <summary>
    ///  Task #...
    ///  Your next task is change IService interface and Service class to
    ///  generic versions and rewrite your services using them
    ///  
    /// </summary>

    public interface IUserProfileService
    {
        Task<UserProfileModel> Create(UserProfileModel userProfile);

        Task<UserProfileModel> GetById(int id);

        Task<IEquatable<UserProfileModel>> GetAll();

        Task<UserProfileModel> update(UserProfileModel userProfile);

        Task Delete(int id);
    }
}
