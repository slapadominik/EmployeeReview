using System;
using System.Linq;
using EmployeeReview.API.DTO;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Controllers
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
        [Authorize(Roles = "Administrator")]
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
                return Unauthorized();
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
                return Unauthorized();
            }
        }
    }
}