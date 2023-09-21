using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HeroManagement.Models.Lookups;
using Microsoft.CodeAnalysis.Razor;

namespace HeroManagement.Models
{

    public class Hero
    {
        public int Id { get; set; }

        [Required]
		[Column(TypeName = "varchar(255)")]
		public string Name { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
		public string Series { get; set; }

        [Required]
		[Column(TypeName = "varchar(255)")]
		public string Power { get; set; }

        [Required]
		[Column(TypeName = "varchar(2048)")]
		public string Description { get; set; }

        [Required]
		[Column(TypeName = "varchar(255)")]
		public string? PhotoPath { get; set; }




    }
}