using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Utilites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.ViewModel
{
	public class RegisterViewModel
	{
		
		[Required]
		[EmailAddress]
		//[RegularExpression(@"^[a-zA-Z0-9!#$%^&*_=+`~.]+@pragimtech.com", ErrorMessage = "Email domain must be pragimtech.com")]
		[ValidEmailDomain(
			allowedDomain: "pragimtech.com",
			ErrorMessage ="Email domain must be pragimtech.com")]

		[Remote("IsEmailInUse", "Account")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Passwords doesn't match")]
		public string ConfirmPassword { get; set; }

		public string City { get; set; }

	}
}
