using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models.Lookups;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employeesList;

        public MockEmployeeRepository()
        {
            employeesList = new List<Employee>
            {
                new Employee(){Id = 1, Name = "Mary", Department = Department.HR, Email = "mary@pragim.com"},
                new Employee(){Id = 2, Name = "John", Department = Department.IT, Email= "john@pragim.com"},
                new Employee(){Id = 3, Name = "Sam", Department = Department.IT, Email = "sam@pragim.com"},

            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = employeesList.Max(e => e.Id) + 1;
            employeesList.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp = employeesList.FirstOrDefault(i => i.Id == id);
            if (emp != null)
                employeesList.Remove(emp);

            return emp;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeesList;
        }

        public Employee GetEmployee(int Id)
        {
            return employeesList.FirstOrDefault(emp => emp.Id == Id);
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            Employee emp = employeesList.FirstOrDefault(i => i.Id == employeeChanges.Id);
            if (emp != null)
            {
                emp.Name = employeeChanges.Name;
                emp.Email = employeeChanges.Email;
                emp.Department = employeeChanges.Department;
            }

            return emp;
        }
    }
}