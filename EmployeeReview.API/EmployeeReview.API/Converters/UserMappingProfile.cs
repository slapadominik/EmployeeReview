using AutoMapper;
using EmployeeReview.API.DTO;
using EmployeeReview.Domain.Entities;

namespace EmployeeReview.API.Converters
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Registration, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Superior, opt => opt.Ignore());
        }
    }
}