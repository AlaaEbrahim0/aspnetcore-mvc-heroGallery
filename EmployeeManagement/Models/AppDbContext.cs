using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
	public class AppDbContext: IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions options): base(options)
		{
			
		}
		public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Seed();

			modelBuilder.Entity<Employee>()
				.Ignore("Biography");

			foreach(var foreignKey in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys()))
			{
				foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
			}

        }

    }
}
