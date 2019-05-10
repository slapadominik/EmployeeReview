using System;
using System.Collections.Generic;
using EmployeeReview.Domain.Reviews.DTO;

namespace EmployeeReview.Domain.Reviews.Services.Interfaces
{
    public interface IReviewsService
    {
        void AddReview(ReviewCommand reviewCommand);
        IEnumerable<ReviewQuery> GetByUserId(Guid userId);
    }
}