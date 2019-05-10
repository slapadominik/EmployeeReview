using AutoMapper;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.Converters.Interfaces;
using EmployeeReview.Domain.Reviews.DTO;

namespace EmployeeReview.Domain.Reviews.Converters
{
    public class ReviewAuthorConverter : IReviewAuthorConverter
    {
        private IMapper _mapper;

        public ReviewAuthorConverter()
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<UserDAO, ReviewAuthor>(); });
            _mapper = mapperConfig.CreateMapper();
        }

        public ReviewAuthor Convert(UserDAO userDao)
        {
            return _mapper.Map<ReviewAuthor>(userDao);
        }
    }
}