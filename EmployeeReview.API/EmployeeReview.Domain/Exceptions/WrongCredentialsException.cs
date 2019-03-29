using System;

namespace EmployeeReview.Domain.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException()
        {
        }

        public WrongCredentialsException(string message) : base(message)
        {
        }
    }
}