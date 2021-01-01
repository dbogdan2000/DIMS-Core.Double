using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class DirectionViewModelProfile : Profile
    {
        public DirectionViewModelProfile()
        {
            CreateMap<DirectionModel, DirectionViewModel>()
                .ReverseMap();
        }
    }
}
