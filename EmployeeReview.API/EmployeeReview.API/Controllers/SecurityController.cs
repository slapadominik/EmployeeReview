using System;
using AutoMapper;
using EmployeeReview.API.DTO;
using EmployeeReview.Domain.Entities;
using EmployeeReview.Domain.Exceptions;
using EmployeeReview.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]Credentials credentials)
        {
            var token = _securityService.Login(credentials.Email, credentials.Password);
            
            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Registration registration)
        {
            var user = _mapper.Map<Registration, User>(registration);
            try
            {
                _securityService.Register(user);
                return Ok();
            }
            catch (EmailAlreadyExistsException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}