using System;

namespace EmployeeReview.Domain.Reviews.DTO
{
    public class ReviewAuthor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}