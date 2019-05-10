using System;
using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.DTO;

namespace EmployeeReview.Domain.Reviews.Repositories.Interfaces
{
    public interface IReviewsRepository
    {
        void Add(ReviewDAO review);
        IEnumerable<ReviewDAO> GetByUserId(Guid id);
    }
}