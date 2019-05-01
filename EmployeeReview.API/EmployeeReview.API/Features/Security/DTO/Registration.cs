namespace EmployeeReview.API.Features.Security.DTO
{
    public class Registration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public int TitleId { get; set; }
    }
}