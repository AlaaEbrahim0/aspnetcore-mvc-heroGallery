using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Models
{
	public class SqlEmployeeRepository : IEmployeeRepository
	{
		private readonly AppDbContext context;
		private readonly ILogger<IEmployeeRepository> logger;

		public SqlEmployeeRepository(AppDbContext context, ILogger<SqlEmployeeRepository> logger)
		{
            this.context = context;
			this.logger = logger;
		}
		public Employee AddEmployee(Employee employee)
		{
			context.Employees.Add(employee);
			context.SaveChanges();
			return employee;
		}
		 
		public Employee DeleteEmployee(int id)
		{
            Employee emp = context.Employees.Find(id);
			if (emp != null)
			{
				context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return emp;
		
        }

        public IEnumerable<Employee> GetAllEmployees()
		{
			return context.Employees;
		}

		public Employee GetEmployee(int Id)
		{
			return context.Employees.Find(Id); 
        }

		public Employee UpdateEmployee(Employee employeeChanges)
		{
			var emp = context.Employees.Attach(employeeChanges);
			emp.State = EntityState.Modified;
			context.SaveChanges();
			return employeeChanges;
        }
    }
}
