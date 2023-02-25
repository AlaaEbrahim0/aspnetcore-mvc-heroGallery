using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                  new Employee
                  {
                      Id = 1,
                      Name = "Mary",
                      Department = Department.IT,
                      Email = "mary@pragimtech.com"
                  },
                  new Employee
                  {
                      Id = 2,
                      Name = "John",
                      Department = Department.IT,
                      Email = "john@pragimtech.com"
                  }
            );
        }

    }
}
