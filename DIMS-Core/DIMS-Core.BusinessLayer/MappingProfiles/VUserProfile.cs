using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class VUserProfile : Profile
    {
        public VUserProfile()
        {
            CreateMap<DataAccessLayer.Models.VUserProfile, VUserProfileModel>().ReverseMap();
        }
    }
}
