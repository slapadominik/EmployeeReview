using AutoMapper;
using EmployeeReview.Domain.Entities;
using EmployeeReview.Infrastructure.DAO;

namespace EmployeeReview.Domain.Converters
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDAO>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}