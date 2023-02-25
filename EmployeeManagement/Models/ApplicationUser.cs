using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace EmployeeManagement.Models
{
	public class ApplicationUser: IdentityUser
	{
		public string City { get; set; }
	}
}
