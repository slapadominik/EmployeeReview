using System.Collections.Generic;
using EmployeeReview.Domain.Entities;

namespace EmployeeReview.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}