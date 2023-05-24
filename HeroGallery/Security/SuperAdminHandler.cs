using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeroManagement.Security
{
	public class SuperAdminHandler: AuthorizationHandler<ManageAdminRolesAndClaimRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimRequirement requirement)
		{

			if (context.User.IsInRole("Super Admin"))
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
