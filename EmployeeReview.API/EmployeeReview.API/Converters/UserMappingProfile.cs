using AutoMapper;
using EmployeeReview.API.DTO;
using EmployeeReview.Domain.Security.DTO;

namespace EmployeeReview.API.Converters
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Registration, Account>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}