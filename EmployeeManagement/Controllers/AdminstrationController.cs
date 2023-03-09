using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminstrationController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly ILogger<AdminstrationController> logger;

		public AdminstrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<AdminstrationController>logger)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
			this.logger = logger;
		}

		[HttpGet]
		public IActionResult UsersList()
		{
			var users = userManager.Users;
			return View(users);
		}


		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var role = new IdentityRole
				{
					Name = model.RoleName
				};
				var result = await roleManager.CreateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("RolesList", "Adminstration");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}


		[HttpGet]
		public IActionResult RolesList()
		{
			var roles = roleManager.Roles;
			return View(roles);
		}

		[HttpGet]
		public async Task<IActionResult> EditRole(string id)
		{
			var role = await roleManager.FindByIdAsync(id);
			if (role == null)
			{
				ViewBag.ErrorMessage = $"Role with ID = {id} cannot be found";
				return View("StatusCodeError");
			}

			var model = new EditRoleViewModel
			{
				Id = id,
				RoleName = role.Name,
			};

			foreach(var user in await userManager.Users.ToListAsync())
			{
				if (await userManager.IsInRoleAsync(user, role.Name))
				{
					model.Users.Add(user.UserName);
				}
			}
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> EditRole(EditRoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var role = await roleManager.FindByIdAsync(model.Id);

				if (role == null)
				{
					ViewBag.ErrorMessage = $"Role with ID = {model.Id} cannot be found";
					return View("StatusCodeError");
				}

				role.Name = model.RoleName;
				var result = await roleManager.UpdateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("RolesList");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}



		[HttpGet]
		public async Task<IActionResult> EditUsersInRole(string roleId)
		{
			ViewBag.roleId = roleId;
			var role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found";
				return View("StatusCodeError");
			}
  
			var model = new List<UserRoleViewModel>();

			foreach (var user in await userManager.Users.ToListAsync())
			{
				var userRoleViewModel = new UserRoleViewModel
				{
					UserId = user.Id,
					UserName = user.UserName,
					IsSelected = false
				};

				if (await userManager.IsInRoleAsync(user, role.Name))
				{
					userRoleViewModel.IsSelected = true;
				}

				model.Add(userRoleViewModel);

			}
			return View(model);

		}
		[HttpPost]
		public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
		{
			var role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found";
				return View("StatusCodeError");
			}

			for (int i = 0; i < model.Count; ++i)
			{
				var user = await userManager.FindByIdAsync(model[i].UserId);
				IdentityResult result = null;

				if (model[i].IsSelected && !await userManager.IsInRoleAsync(user, role.Name))
				{
					result = await userManager.AddToRoleAsync(user, role.Name);
				}

				else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
				{
					result = await userManager.RemoveFromRoleAsync(user, role.Name);
				}

				else
				{
					continue;
				}

			}

			return RedirectToAction("EditRole", new { id = roleId });
			
		}

		[HttpGet]
		public async Task<IActionResult> EditUserAsync (string id)
		{
			var user = await userManager.FindByIdAsync (id);
			if (user == null)
			{
				ViewBag.ErrorMessage = $"User with ID = {id} cannot be found";
				return View("StatusCodeError");
			}

			var roles = await userManager.GetRolesAsync(user);
			var claims = await userManager.GetClaimsAsync(user);

			var model = new EditUserViewModel
			{
				Id = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				City = user.City,
				Roles = roles,
				Claims = claims.Select(c => c.Value).ToList()
			};


			return View(model);

		}

		[HttpPost]
		public async Task<IActionResult> EditUserAsync(EditUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByIdAsync(model.Id);
				if (user == null)
				{
					ViewBag.ErrorMessage = $"User with ID = {model.Id} cannot be found";
					return View("StatusCodeError");
				}

				user.UserName = model.UserName;
				user.Email = model.Email;
				user.City = model.City;

				var result = await userManager.UpdateAsync(user);
				
				if (result.Succeeded)
				{
					return RedirectToAction("UsersList", "adminstration");
				}

				foreach(var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

		public async Task<IActionResult> DeleteUserAsync(string id)
		{
			var user = await userManager.FindByIdAsync(id);
			if (user == null)
			{
				ViewBag.ErrorMessage = $"User with ID = {id} cannot be found";
				return View("StatusCodeError");
			}
			var result = await userManager.DeleteAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("UsersList", "Adminstration");
			}
			foreach(var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
			return View("ListUsers");

		}

        public async Task<IActionResult> DeleteRoleAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} cannot be found";
                return View("StatusCodeError");
            }
            try
			{
				var result = await roleManager.DeleteAsync(role);
				if (result.Succeeded)
				{
					return RedirectToAction("RolesList", "Adminstration");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View("RolesList");
			}
			catch(DbUpdateException ex)
			{
				logger.LogError($"Error Deleting Role: {ex.Message}");

				ViewBag.ErrorTitle = $"{role.Name} role is in use";
				ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role" +
					$"If you want to delete this role, please remove the users from the " +
					$"the role in and then try again";

				return View("ExceptionError");
			}

        }


    }
}
