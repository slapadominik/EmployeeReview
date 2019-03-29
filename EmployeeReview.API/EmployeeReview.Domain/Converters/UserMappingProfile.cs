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
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UserRole, opt => opt.Ignore());
            CreateMap<UserDAO, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Superior, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore());
                
            CreateMap<Role, RoleDAO>();
            CreateMap<RoleDAO, Role>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}