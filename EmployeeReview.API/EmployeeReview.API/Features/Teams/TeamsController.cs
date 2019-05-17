using EmployeeReview.Domain.Teams.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Features.Teams
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private ITeamsService _teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        /// <summary>
        /// Gets information about existing users' teams.
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_teamsService.Get());
        }
    }
}