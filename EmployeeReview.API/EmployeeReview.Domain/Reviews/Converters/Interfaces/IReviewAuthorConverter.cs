using System;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.DTO;

namespace EmployeeReview.Domain.Reviews.Converters.Interfaces
{
    public interface IReviewAuthorConverter
    {
        ReviewAuthor Convert(UserDAO userDao);
    }
}