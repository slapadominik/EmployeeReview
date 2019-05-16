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
    [Authorize]
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

        [HttpGet]
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

        [HttpPatch("{userId:guid}/jobInformation")]
        public IActionResult EditPersonalInformation([FromRoute] Guid userId, [FromBody]JobInformation userInfo)
        {
            try
            {
                _userManagementService.UpdateUsersJobInformation(new UserJobInformation{UserId = userId, JobTitle = userInfo.JobTitleId, SupervisorId = userInfo.SupervisorId});
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