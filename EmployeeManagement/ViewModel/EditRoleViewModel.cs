using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
	public class EditRoleViewModel
	{
        public string Id { get; set; }

		[Required(ErrorMessage = "Role name is required")]
		public string RoleName { get; set; }

		public List<string> Users { get; set; } = new();

    }
}
