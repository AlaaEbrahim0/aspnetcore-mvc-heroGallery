using System.ComponentModel.DataAnnotations;
using HeroManagement.Models.Lookups;
using Microsoft.CodeAnalysis.Razor;

namespace HeroManagement.Models
{

    public class Hero
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public string Series { get; set; }

        [Required]
        public string Power { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PhotoPath { get; set; }




    }
}