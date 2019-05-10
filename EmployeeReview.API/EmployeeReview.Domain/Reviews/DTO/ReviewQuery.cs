using System;

namespace EmployeeReview.Domain.Reviews.DTO
{
    public class ReviewQuery
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public byte Rate { get; set; }
        public DateTime Created { get; set; }
        public ReviewAuthor Author { get; set; }
        public Guid UserId { get; set; }
    }
}