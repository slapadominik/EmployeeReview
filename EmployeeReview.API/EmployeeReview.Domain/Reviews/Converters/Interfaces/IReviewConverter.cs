using System;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.DTO;

namespace EmployeeReview.Domain.Reviews.Converters.Interfaces
{
    public interface IReviewConverter
    {
        ReviewDAO Convert(ReviewCommand reviewCommand, DateTime created, Guid authorId);
        ReviewQuery Convert(ReviewDAO reviewDao);
    }
}