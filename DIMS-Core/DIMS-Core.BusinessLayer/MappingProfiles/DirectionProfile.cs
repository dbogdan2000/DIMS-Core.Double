using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DirectionEntity = DIMS_Core.DataAccessLayer.Models.Direction;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    class DirectionProfile : Profile
    {
        public DirectionProfile()
        {
            CreateMap<DirectionEntity, DirectionModel>()
                .ReverseMap();
        }
    }
}
