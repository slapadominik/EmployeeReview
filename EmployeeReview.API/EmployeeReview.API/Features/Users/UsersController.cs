using System;
using System.Collections.Generic;
using EmployeeReview.API.DTO;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.Reviews.DTO;
using EmployeeReview.Domain.Reviews.Services.Interfaces;
using EmployeeReview.Domain.UserManagement.DTO;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Features.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IReviewsService _reviewsService;

        public UsersController(IUserManagementService userManagementService, IReviewsService reviewsService)
        {
            _userManagementService = userManagementService;
            _reviewsService = reviewsService;
        }

        /// <summary>
        /// Gets information about existing users in the system.
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] string role, [FromQuery] Guid? supervisorId)
        {
            IEnumerable<UserDetails> users = new List<UserDetails>();
            if (role != null)
            {
                users = _userManagementService.GetByRole(role);
            }
            else if (supervisorId != null)
            {
                users = _userManagementService.GetBySupervisorId(supervisorId.Value);
            }
            else
            {
                users = _userManagementService.GetAll();
            }

            return Ok(users);
        }

        /// <summary>
        /// Gets detailed information about existing user.
        /// </summary>
        /// /// <param name="id">ID of the user</param>
        /// <returns>Detailed information about user</returns>
        [HttpGet("{id:guid}")]
        [Authorize]
        public IActionResult GetDetails([FromRoute] Guid id)
        {
            try
            {
                var employeeDetails = _userManagementService.GetDetails(id);
                return Ok(employeeDetails);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Updates user's job information, such as supervisor and job title.
        /// </summary>
        /// /// <param name="userId">ID of the updating user.</param>
        [HttpPatch("{userId:guid}/jobInformation")]
        [Authorize]
        public IActionResult EditPersonalInformation([FromRoute] Guid userId, [FromBody]JobInformation userInfo)
        {
            try
            {
                _userManagementService.UpdateUsersJobInformation(
                    new UserJobInformation
                    {
                        UserId = userId,
                        JobTitle = userInfo.JobTitleId,
                        SupervisorId = userInfo.SupervisorId,
                        TeamId = userInfo.TeamId
                    });
                return Ok();
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        
        [HttpPut("{userId:guid}/roles")]
        [Authorize(Roles = Consts.Roles.Administrator)]
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

        [HttpPost("{userId:guid}/reviews")]
        [Authorize]
        public IActionResult AddReview(Guid userId, [FromBody] DTO.Review review)
        {
            try
            {
                _reviewsService.AddReview(new ReviewCommand {UserId = userId, Rate = review.Rate, Content = review.Content});
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId:guid}/reviews")]
        [Authorize]
        public IActionResult GetReview(Guid userId)
        {
            try
            {
                var result = _reviewsService.GetByUserId(userId);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}