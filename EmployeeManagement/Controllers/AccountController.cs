using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
		public async Task<IActionResult> Login(string returnUrl)
		{
			var model = new LoginViewModel
			{
				ReturnUrl = returnUrl,
				ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};
			return View(model);
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

		[AllowAnonymous]
		[HttpPost]
		public IActionResult ExternalLogin(string provider, string returnUrl)
		{
			var redirectUrl = Url.Action("ExternalLoginCallBack", "Account", 
				new {ReturnUrl = returnUrl});
			
			var properites = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return new ChallengeResult(provider, properites);
		}

		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginCallBack (string returnUrl = null, string remoteError = null)
		{
			//If the returnUrl is null redirect the uset to the home page
			returnUrl = returnUrl ?? Url.Content("~");

			LoginViewModel model = new LoginViewModel
			{
				ReturnUrl = returnUrl,
				ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};

			//Error handling 

			if (remoteError != null)
			{
				ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
				return View("Login", model);
			}


			//We obtain the authentication info about the user
			//the user data the provider name, provider key etc ... 
			var info = await signInManager.GetExternalLoginInfoAsync();


			//Error Handling
			if (info == null)
			{
				ModelState.AddModelError(string.Empty, $"Error loading external login information: {remoteError}");
				return View("Login", model);
			}


			//Now we can easily sign in using the ExternalLoginSignInAsync method passing it the login provider(google in our case)
			//the generated provider key by google for the entered user 
			var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
				isPersistent: false, bypassTwoFactor: true);

			
			if (signInResult.Succeeded)
			{
				return LocalRedirect(returnUrl);
			}

			//If the login did not succeed we want to check if the user has a local account in our system and link it if it does exist
			else
			{

				var email = info.Principal.FindFirstValue(ClaimTypes.Email);

				if (email != null)
				{
					var user = await userManager.FindByEmailAsync(email);

					if (user == null)
					{
						user = new ApplicationUser
						{
							Email = email,
							UserName = email
						};

						await userManager.CreateAsync(user);
					}

					await userManager.AddLoginAsync(user, info);
					await signInManager.SignInAsync(user, isPersistent: false);

					return LocalRedirect(returnUrl);
				}

				ViewBag.ErrorTitle = $"Email claim not received from {info.LoginProvider}";
				ViewBag.ErrorMessage = "Please contact support on pargimtech@pragimtech.com";

				return View("Error");
			}


		}





	}
}
