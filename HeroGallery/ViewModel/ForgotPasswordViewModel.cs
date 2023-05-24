using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HeroManagement.ViewModel
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
    }
}
