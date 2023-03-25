using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int Id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employeeChanges);
        Employee DeleteEmployee(int id);

    }
}