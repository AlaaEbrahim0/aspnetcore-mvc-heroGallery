using System;
using System.Collections.Generic;
using HeroManagement.Models.Lookups;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HeroManagement.Models
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasData(new List<Hero>()
                {
                    new Hero
                    {
                        Id = 1,
                        Name = "Monkey D. Luffy",
                        Series = "One Piece",
                        PhotoPath = "44e4c0b7-9b1d-4c92-b085-a6b9a5a71bb3_920af967-fa93-4724-8e44-905d625cd4a4_28728657-ad47-41ac-adb2-39d24a2ea816_fb95b7fea0ea1223185714531c4b6772.jpg",
                        Gender = Gender.Male,
                        Description = "Monkey D. Luffy is the main protagonist of the popular anime and manga series 'One Piece.' He is a young pirate with a rubber body who sets out on a journey to find the legendary treasure, the One Piece, and become the Pirate King.",
                        Power = "Rubber"
                    },
                    new Hero
                    {
                        Id = 2,
                        Name = "Roronoa Zoro",
                        Series = "One Piece",
                        PhotoPath = "76b3b842-904f-4c06-bc35-40de1a030539_8470b453-8210-463b-a1-c88535611631_5123e2c8908fde0f05e17d7f401de6c4_2977c7079689fc77aef47678618e4118.webp",
                        Gender = Gender.Male,
                        Description = "Zoro has devoted his life to becoming the world's strongest swordsman. Even before joining the crew, he was well-renowned for his outstanding abilities and accomplishments in battle. His skills drastically improved after becoming the combatant of the Straw Hat Pirates and entering a two-year training period under the 'Strongest Swordsman in the World', Dracule Mihawk.",
                        Power = "Swords Man"
                    },
                    new Hero
                    {
                        Id = 3,
                        Name = "Brook The Bone",
                        Series = "One Piece",
                        PhotoPath = "fa142892-a759-49e4-a8f3-69a80241bfd3_380a0053-324b-4bb4-b1fb-e15aeb82d9ee_how_draw_brook_one_piece.jpg",
                        Gender = Gender.Male,
                        Description = "As much as Brook normally goofs around on the ship engaging in acts of silliness with Luffy, he is still a formidable opponent. Due to his previous experiences and skills that he amassed from the days when the Pirate King Gol D. Roger was still active, Brook, in all respects, is a veteran pirate (though these attributes are somewhat downplayed by his overall demeanor, along with the fact that his isolation in the Florian Triangle seemed to have eroded his knowledge of modern society). Brook is a talented swordsman, has extraordinary speed due to his light frame, and is astonishingly difficult to harm because of his undead state.",
                        Power = "Dead Swords Man"
                    },
                    new Hero
                    {
                        Id = 4,
                        Name = "Zaraki Kenpachi",
                        Series = "Bleach",
                        PhotoPath = "7759dbeb-3064-474d-92bc-eb280e0ca945_89eb6fc7-2d62-4fcf-a4af-aade8e7e5e14_9d20cb0f45696e7c0f363e75c9cea33c--manga-art-manga-anime.jpg",
                        Gender = Gender.Male,
                        Description = "Kenpachi Zaraki is sthe current captain of the 11th Division in the Gotei 13. He is the eleventh Kenpachi to hold the position. His first lieutenant was Yachiru Kusajishi and his current lieutenant is Ikkaku Madarame.",
                        Power = "Swords Man"
                    },
                    new Hero
                    {

                        Id = 5,
                        Name = "Uchiha Itachi",
                        Series = "Naruto",
                        PhotoPath = "edf7bbff-6e0f-44d7-9537-87c87043e73d_tumblr_py7mzyNngZ1rmvvveo1_500-1591.jpg",
                        Gender = Gender.Male,
                        Description = "Itachi Uchiha was a shinobi of Konohagakure's Uchiha clan who served as an Anbu Captain. He later became an international criminal after murdering his entire clan, sparing only his younger brother, Sasuke. He afterwards joined the international criminal organisation known as Akatsuki, whose activity brought him into frequent conflict with Konoha and its ninja — including Sasuke who sought to avenge their clan by killing Itachi. Following his death, Itachi's motives were revealed to be more complicated than they seemed and that his actions were only ever in the interest of his brother and village, making him remain a loyal shinobi of Konohagakure to the very end.",
                        Power = "Illusion"
                    },
                    new Hero
                    {
                        Id = 6,
                        Name = "Uchiha Madara",
                        Series = "Naruto",
                        PhotoPath = "53f05a7f-adb5-4db1-a73f-696db2354f74_desktop-wallpaper-uchiha-madara-black-and-white-naruto-drawings-naruto-art-madara-uchiha.jpg",
                        Description = "Madara Uchiha was the legendary leader of the Uchiha Clan. He founded Konohagakure alongside his childhood friend and rival, Hashirama Senju, with the intention of bringing about an era of peace. When the two couldn't agree on how to achieve that peace, they fought for control of the village, a conflict which ended in Madara's death. Madara, however, rewrote his death and went into hiding to work on his own plans. Unable to complete it in his natural life, he entrusted his knowledge and plans to Obito shortly before his actual death. Years later, Madara would be revived, only to see his plans foiled and ultimately, and finally, realising the error of his ways and making amends with Hashirama before his final death.",
                        Gender = Gender.Male,
                        Power = "Multiple"
                    },
                    new Hero
                    {
                        Id = 7,
                        Name = "Dofilamingo",
                        Series = "One Piece",
                        PhotoPath = "3a35ad88-e3f3-4920-ba7f-e5a259e214bd_3-zeta-doffy-4.jpg",
                        Description = "Donquixote Doflamingo, nicknamed 'Heavenly Yaksha', is the captain of the Donquixote Pirates",
                        Gender = Gender.Male,
                        Power = "String"
                    }
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    Email = "superadmin@mail.com",
                    PasswordHash = "abc123456789",
                    EmailConfirmed = true,
                });

        }

    }
}