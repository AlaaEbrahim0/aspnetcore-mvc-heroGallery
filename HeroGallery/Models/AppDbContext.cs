using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeroManagement.Models
{
	public class AppDbContext: IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions options): base(options)
		{
			
		}
		public DbSet<Hero> Heros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
			
			foreach(var foreignKey in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys()))
			{
				foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
			}

        }

    }
}
