using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace HeroManagement.ViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
        public string City { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
        public List<string> Claims { get; set; } = new List<string>();

    }
}
