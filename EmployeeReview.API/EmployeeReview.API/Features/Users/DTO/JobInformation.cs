using System;

namespace EmployeeReview.API.DTO
{
    public class JobInformation
    {
        public int JobTitleId { get; set; }
        public Guid SupervisorId { get; set; }
    }
}