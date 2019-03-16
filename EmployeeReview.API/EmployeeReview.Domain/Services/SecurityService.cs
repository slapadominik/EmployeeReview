﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EmployeeReview.Domain.Entities;
using EmployeeReview.Domain.Exceptions;
using EmployeeReview.Domain.Helpers;
using EmployeeReview.Domain.Services.Interfaces;
using EmployeeReview.Infrastructure.DAO;
using EmployeeReview.Infrastructure.DbContexts;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeReview.Domain.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISecurityHelper _securityTokenHelper;
        private readonly IMapper _mapper;

        public SecurityService(ApplicationDbContext dbContext, ISecurityHelper securityTokenHelper, IMapper mapper)
        {
            _dbContext = dbContext;
            _securityTokenHelper = securityTokenHelper;
            _mapper = mapper;
        }

        public void Register(User user)
        {
            var existingUser =  _dbContext.Users.SingleOrDefault(x => x.Email == user.Email);

            if (existingUser != null)
            {
                throw new EmailAlreadyExistsException($"Email already exists!");
            }
            var userDAO = _mapper.Map<User, UserDAO>(user);
            var (passwordHash, passwordSalt) = _securityTokenHelper.HashPassword(user.Password);
            userDAO.Id = Guid.NewGuid();
            userDAO.Password = passwordHash;
            userDAO.PasswordSalt = passwordSalt;

            _dbContext.Users.Add(userDAO);
            if (_dbContext.SaveChanges() != 1)
            {
                throw new DatabaseException();
            }
        }

        public string Login(string email, string password)
        {
            throw new NotImplementedException();
            //return _securityTokenHelper.CreateToken(user);
        }
    }
}