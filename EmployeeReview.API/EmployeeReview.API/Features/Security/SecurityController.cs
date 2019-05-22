using System;
using AutoMapper;
using EmployeeReview.API.Features.Security.DTO;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.Security.DTO;
using EmployeeReview.Domain.Security.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Features.Security
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

        /// <summary>
        /// Authorize user in the system. 
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody]Credentials credentials)
        {
            try
            {
                var token = _securityService.Login(credentials.Email, credentials.Password);
                return Ok(token);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (WrongCredentialsException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Register user in the system. 
        /// </summary>
        [HttpPost("register")]
        public IActionResult Register([FromBody] Registration registration)
        {
            var user = _mapper.Map<Registration, Account>(registration);
            try
            {
                _securityService.Register(user);
                return Ok();
            }
            catch (EmailAlreadyExistsException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}