using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;

namespace EmployeeManagement.Models
{

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Name cannot be less than 10 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9!#$%^&*-+=.~`_]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$", ErrorMessage ="Invalid Email Format")]
        [Display (Name = "Office Email")]
        public string Email { get; set; }

        [Required]
        public Department? Department { get; set; }
        public string PhotoPath { get; set; }


    }
}