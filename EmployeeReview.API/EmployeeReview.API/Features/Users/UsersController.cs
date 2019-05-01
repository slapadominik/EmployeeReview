using System;
using System.Collections.Generic;
using EmployeeReview.API.Consts;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.UserManagement.DTO;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserPersonalInformation = EmployeeReview.API.DTO.UserPersonalInformation;

namespace EmployeeReview.API.Features.Users
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UsersController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Administrator)]
        public IActionResult GetAll()
        {
            var employees = _userManagementService.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetDetails([FromRoute] Guid id)
        {
            try
            {
                var employeeDetails = _userManagementService.GetDetailsAboutMe(id);
                return Ok(employeeDetails);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult EditPersonalInformation([FromRoute] Guid id, [FromBody]UserPersonalInformation userInfo)
        {
            try
            {
                _userManagementService.UpdatePersonalInformation(
                    new Domain.UserManagement.DTO.UserPersonalInformation
                        {Id = id, FirstName = userInfo.FirstName, LastName = userInfo.LastName}
                );
                return Ok();
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{userId:guid}/roles")]
        [Authorize(Roles = Roles.Administrator)]
        public IActionResult EditUserRoles([FromRoute] Guid userId, [FromBody] IEnumerable<Role> roles)
        {
            try
            {
                _userManagementService.EditUserRoles(userId, roles);
                return Ok();
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

    }
}