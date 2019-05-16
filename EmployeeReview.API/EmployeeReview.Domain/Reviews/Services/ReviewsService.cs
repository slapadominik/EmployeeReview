using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Exceptions;
using EmployeeReview.Domain.Common.Security;
using EmployeeReview.Domain.Reviews.Converters.Interfaces;
using EmployeeReview.Domain.Reviews.DTO;
using EmployeeReview.Domain.Reviews.Repositories.Interfaces;
using EmployeeReview.Domain.Reviews.Services.Interfaces;
using EmployeeReview.Domain.UserManagement.Repositories.Interfaces;

namespace EmployeeReview.Domain.Reviews.Services
{
    public class ReviewsService : IReviewsService
    {
        private IReviewsRepository _reviewsRepository;
        private IReviewConverter _reviewConverter;
        private IUserRepository _userRepository;
        private readonly IPrincipalHelper _principalHelper;

        public ReviewsService(IReviewsRepository reviewsRepository, IReviewConverter reviewConverter, IUserRepository userRepository, IPrincipalHelper principalHelper)
        {
            _reviewsRepository = reviewsRepository;
            _reviewConverter = reviewConverter;
            _userRepository = userRepository;
            _principalHelper = principalHelper;
        }

        public void AddReview(ReviewCommand reviewCommand)
        {
            if (_userRepository.GetUserDetailById(reviewCommand.UserId) == null)
            {
                throw new UserNotFoundException($"User with id {reviewCommand.UserId} not exists.");
            }
            var loggedUserId = _principalHelper.Principal.Claims.SingleOrDefault(x => x.Type == "jti");
            if (loggedUserId == null)
            {
                throw new UnauthorizedOperationException();
            }
            _reviewsRepository.Add(_reviewConverter.Convert(reviewCommand, DateTime.Now, Guid.Parse(loggedUserId.Value)));
        }

        public IEnumerable<ReviewQuery> GetByUserId(Guid userId)
        {
            var user = _userRepository.GetUserDetailById(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {userId} not exists.");
            }
            return _reviewsRepository.GetByUserId(userId).Select(x => _reviewConverter.Convert(x));
        }
    }
}