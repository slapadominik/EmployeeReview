using System;

namespace EmployeeReview.Domain.Common.Exceptions
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