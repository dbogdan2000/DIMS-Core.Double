using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.BusinessLayer.Models.Account;
using DIMS_Core.Identity.Entities;
using UserProfileEntity = DIMS_Core.DataAccessLayer.Models.UserProfile;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpModel, User>()
                .ForMember(q => q.Email, w => w.MapFrom(q => q.Email))
                .ForMember(q => q.UserName, w => w.MapFrom(q => q.Email));

            CreateMap<UserProfileEntity, UserProfileModel>()
                .ReverseMap();
        }
    }
}