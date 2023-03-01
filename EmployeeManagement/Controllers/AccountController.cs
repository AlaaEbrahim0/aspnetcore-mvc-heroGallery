using System.Globalization;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog.Time;

namespace EmployeeManagement.Controllers
{
	public class AccountController : Controller
	{
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{ 
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
		public IActionResult Login()
        {
            return View();
        }

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{

				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email
				};
				var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
						return Redirect(returnUrl);

					return RedirectToAction("index", "home");
				}

				ModelState.AddModelError("", "Invalid Login Attempt");
			}

			return View(model);
		}


		[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email,
					City = model.City
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
					if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
					{
						return RedirectToAction("UsersList", "Adminstration");
					}

					await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);

        }

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[AcceptVerbs("Get", "Post")] // The same as [HttpPost][HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> IsEmailInUse(string email)
		{
			
			var user = await userManager.FindByEmailAsync(email);
			if (user == null)
			{
				return Json(true);
			}

			return Json($"Email {email} is already in use");

		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View();
		}


	}
}
