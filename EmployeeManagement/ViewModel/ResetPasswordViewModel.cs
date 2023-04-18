using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.ViewModel
{
	public class ResetPasswordViewModel
	{

		[Required]
		[EmailAddress] 
		public string Email { get; set; }

        public string Token { get; set; }

        [Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }



    }
}
