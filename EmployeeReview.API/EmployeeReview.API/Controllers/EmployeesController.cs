using System;
using System.Linq;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public EmployeesController(IUserManagementService userManagementService)
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
        public IActionResult GetDetailsAboutMe(Guid id)
        {            
            var userIdClaim = User.Claims.SingleOrDefault(x => x.Type == "jti");
            if (userIdClaim?.Value != id.ToString())
            {
                return Unauthorized();
            }

            var employeeDetails =_userManagementService.GetDetailsAboutMe(Guid.Parse(userIdClaim.Value));
            return Ok(employeeDetails);
        }
    }
}