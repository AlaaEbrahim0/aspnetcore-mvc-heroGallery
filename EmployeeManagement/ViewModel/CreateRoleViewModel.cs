using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Role Name")]
		public string RoleName { get; set; }
    }
}
