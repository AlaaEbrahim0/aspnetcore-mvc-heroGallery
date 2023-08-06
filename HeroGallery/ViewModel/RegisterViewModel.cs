using System.ComponentModel.DataAnnotations;
using HeroManagement.Utilites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HeroManagement.ViewModel
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@gmail\.com\b", ErrorMessage = "Email address must be from gmail.com domain")]
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
