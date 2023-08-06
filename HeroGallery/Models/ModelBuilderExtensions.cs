using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using HeroManagement.Models.Lookups;
using HeroManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HeroManagement.Models
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            string json = File.ReadAllText("models/heroes.json");
            var hereos = JsonConvert.DeserializeObject<List<Hero>>(json);

            modelBuilder.Entity<Hero>()
                .HasData(hereos);

            modelBuilder.Entity<IdentityRole>()
                .HasData(new List<IdentityRole>
                {
                    new IdentityRole {Name = "USER"},
                    new IdentityRole {Name = "ADMIN"},
                    new IdentityRole {Name = "SUPER ADMIN"},
                });  
        }

    }
}