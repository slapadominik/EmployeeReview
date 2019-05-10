using System;

namespace EmployeeReview.Domain.Reviews.DTO
{
    public class ReviewCommand
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public byte Rate { get; set; }
    }
}