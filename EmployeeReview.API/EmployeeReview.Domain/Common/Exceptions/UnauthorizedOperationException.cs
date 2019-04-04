using System;

namespace EmployeeReview.Domain.Common.Exceptions
{
    public class UnauthorizedOperationException : Exception
    {
        public UnauthorizedOperationException()
        {
        }

        public UnauthorizedOperationException(string message) : base(message)
        {
        }
    }
}