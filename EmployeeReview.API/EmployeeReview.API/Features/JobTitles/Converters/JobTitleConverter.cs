using AutoMapper;
using EmployeeReview.API.Features.JobTitles.Converters.Interfaces;
using EmployeeReview.API.Features.JobTitles.DTO;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.DTO;

namespace EmployeeReview.API.Features.JobTitles.Converters
{
    public class JobTitleConverter : IJobTitleConverter
    {
        private IMapper _mapper;
        public JobTitleConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<JobTitleDAO, JobTitle>(); });
            _mapper = mapperConfig.CreateMapper();
        }
        public JobTitle Convert(JobTitleDAO jobTitle)
        {
            return _mapper.Map<JobTitle>(jobTitle);
        }
    }
}