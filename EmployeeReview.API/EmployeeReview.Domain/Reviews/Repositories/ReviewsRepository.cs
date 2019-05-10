using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeReview.Domain.Common.Persistence;
using EmployeeReview.Domain.Common.Persistence.DAO;
using EmployeeReview.Domain.Reviews.Repositories.Interfaces;

namespace EmployeeReview.Domain.Reviews.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ReviewDAO review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ReviewDAO> GetByUserId(Guid id)
        {
            return _dbContext.Reviews.Where(x => x.UserId == id).ToList();
        }
    }
}