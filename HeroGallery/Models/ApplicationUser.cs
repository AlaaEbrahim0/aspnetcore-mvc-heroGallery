using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace HeroManagement.Models
{
	public class ApplicationUser: IdentityUser
	{
		public string City { get; set; }
	}
}
