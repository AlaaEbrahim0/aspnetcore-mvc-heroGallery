using System.ComponentModel.DataAnnotations;

namespace HeroManagement.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Role Name")]
		public string RoleName { get; set; }
    }
}
