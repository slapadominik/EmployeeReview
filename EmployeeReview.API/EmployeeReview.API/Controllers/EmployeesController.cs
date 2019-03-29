using System;
using System.Linq;
using EmployeeReview.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
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

            var employeeDetails =_employeeService.GetDetailsAboutMe(Guid.Parse(userIdClaim.Value));
            return Ok(employeeDetails);
        }
    }
}