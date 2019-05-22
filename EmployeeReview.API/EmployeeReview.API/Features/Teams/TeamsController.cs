using System;
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

        /// <summary>
        /// Gets information about users' details from given team.
        /// </summary>
        [HttpGet("{teamId}/users")]
        [Authorize]
        public IActionResult GetUsersForSpecificTeam([FromRoute] int teamId)
        {
            try
            {
                var users = _teamsService.GetUsersDetailedByTeamId(teamId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}