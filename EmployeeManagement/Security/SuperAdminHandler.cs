using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Security
{
	public class SuperAdminHandler: AuthorizationHandler<ManageAdminRolesAndClaimRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimRequirement requirement)
		{
			var authFilterContext = context.Resource as AuthorizationFilterContext;
			if (authFilterContext == null)
			{
				return Task.CompletedTask;
			}

			if (context.User.IsInRole("Super Admin"))
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
