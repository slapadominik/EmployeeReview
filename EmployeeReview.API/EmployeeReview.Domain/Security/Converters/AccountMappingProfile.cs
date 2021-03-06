﻿using AutoMapper;
using EmployeeReview.Domain.Security.DTO;
using RoleDAO = EmployeeReview.Domain.Common.Persistence.DAO.RoleDAO;
using UserDAO = EmployeeReview.Domain.Common.Persistence.DAO.UserDAO;

namespace EmployeeReview.Domain.Security.Converters
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, UserDAO>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UserRole, opt => opt.Ignore());
            CreateMap<UserDAO, Account>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore());
                
            CreateMap<Role, RoleDAO>();
            CreateMap<RoleDAO, Role>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}