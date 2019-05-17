using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Features.Roles
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RolesController : Controller
    {
        private IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        /// <summary>
        /// Gets information about system users' roles.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = Consts.Roles.Administrator)]
        public IActionResult GetAll()
        {
            var employees = _rolesService.GetAll();
            return Ok(employees);
        }
    }
}