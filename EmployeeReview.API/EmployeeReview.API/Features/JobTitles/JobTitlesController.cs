using System.Linq;
using EmployeeReview.API.Features.JobTitles.Converters.Interfaces;
using EmployeeReview.Domain.JobTitles.Repositories.Interfaces;
using EmployeeReview.Domain.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeReview.API.Features.JobTitles
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitlesRepository _jobTitlesRepository;
        private readonly IJobTitleConverter _jobTitleConverter;

        public JobTitlesController(IJobTitlesRepository jobTitlesRepository, IJobTitleConverter jobTitleConverter)
        {
            _jobTitlesRepository = jobTitlesRepository;
            _jobTitleConverter = jobTitleConverter;
        }

        /// <summary>
        /// Gets information about existing job titles in the company.
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var jobTitlesDao = _jobTitlesRepository.Get();
            return Ok(jobTitlesDao.ToList().ConvertAll(x => _jobTitleConverter.Convert(x)));
        }
    }
}