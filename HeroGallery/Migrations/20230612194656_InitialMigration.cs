using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroGallery.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "860f6dc8-9cfe-415c-933b-2cfc80160085", "8892b604-f159-463a-a817-06514b42f84a", "SUPER ADMIN", null },
                    { "d18ee0c8-c942-4e56-9e53-a5bde475d6d1", "5f39fb9a-91ee-4e73-bdc2-979463297216", "ADMIN", null },
                    { "e31d4ac0-129e-4b78-aa0a-d7e57cec96d0", "3b6ca02a-71eb-4220-8421-9ee7edc5667e", "USER", null }
                });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Description", "Gender", "Name", "PhotoPath", "Power", "Series" },
                values: new object[,]
                {
                    { 1, "The captain of the Straw Hat Pirates, Luffy has the ability to stretch his body like rubber. He is a fearless and determined fighter who will stop at nothing to become the Pirate King.", 0, "Monkey D. Luffy", "/images/luffy.jpg", "Gomu Gomu no Mi (Rubber-Rubber Fruit)", "One Piece" },
                    { 2, "The main character of the Naruto series, Naruto has the power of the Nine-Tailed Fox sealed inside him. He is a ninja who dreams of becoming the Hokage, the leader of his village.", 0, "Naruto Uzumaki", "/images/naruto.jpg", "Nine-Tailed Fox", "Naruto" },
                    { 3, "A high school student who can see ghosts, Ichigo gains the power of a Soul Reaper and fights to protect his friends and family from evil spirits.", 0, "Ichigo Kurosaki", "/images/ichigo.jpg", "Zanpakuto (Soul Slayer)", "Bleach" },
                    { 4, "A Saiyan warrior from the planet Vegeta, Goku is the main protagonist of the Dragon Ball series. He possesses incredible strength and fighting abilities, and is known for his kind heart and love of adventure.", 0, "Goku", "/images/goku.jpg", "Super Saiyan", "Dragon Ball" },
                    { 5, "A bored and unfulfilled hero who can defeat any opponent with a single punch, Saitama is the protagonist of the One Punch Man series. He seeks to find a worthy opponent who can challenge him.", 0, "Saitama", "/images/saitama.jpg", "Superhuman strength", "One Punch Man" },
                    { 6, "A young alchemist who lost his arm and leg trying to bring his mother back to life, Edward is the main protagonist of the Fullmetal Alchemist series. He and his brother Alphonse search for the Philosopher's Stone to restore their bodies.", 0, "Edward Elric", "/images/edward.jpg", "Alchemy", "Fullmetal Alchemist" },
                    { 7, "A prince of the Britannian Empire who gains the power of Geass, which allows him to control people's minds, Lelouch seeks to overthrow his father and create a better world for his sister Nunnally.", 0, "Lelouch vi Britannia", "/images/lelouch.jpg", "Geass (Mind control)", "Code Geass" },
                    { 8, "A high school student who gains the power to kill anyone whose name he writes in a notebook, Light seeks to create a world free of crime and become its god.", 0, "Light Yagami", "/images/light.jpg", "Death Note (Killing notebook)", "Death Note" },
                    { 9, "A former member of the Uchiha clan who seeks revenge against his brother, Sasuke is a skilled ninja who possesses the Sharingan, a powerful eye technique.", 0, "Sasuke Uchiha", "/images/sasuke.jpg", "Sharingan", "Naruto" },
                    { 10, "A proud and stubborn prince of the Saiyan race, Vegetacontinuing from the previous message...", 0, "Vegeta", "/images/vegeta.jpg", "Super Saiyan", "Dragon Ball" },
                    { 11, "A skilled ninja who serves as the mentor of Naruto and his team, Kakashi possesses the Sharingan and is known for his cool and calm demeanor.", 1, "Kakashi Hatake", "/images/kakashi.jpg", "Sharingan", "Naruto" },
                    { 12, "A young boy who dreams of becoming a Hunter like his father, Gon possesses the power of Nen and sets out on a journey to find his father and become a great Hunter himself.", 1, "Gon Freecss", "/images/gon.jpg", "Nen", "Hunter x Hunter" },
                    { 13, "The former number one hero and the symbol of peace, All Might passes on his power of One For All to Izuku Midoriya and trains him to become the next symbol of peace.", 1, "All Might", "/images/allmight.jpg", "One For All", "My Hero Academia" },
                    { 14, "The captain of the Survey Corps and the strongest soldier in humanity's fight against the Titans, Levi is known for his exceptional combat skills and his clean-freak tendencies.", 1, "Levi Ackerman", "/images/levi.jpg", "Omnidirectional Mobility Gear", "Attack on Titan" },
                    { 15, "A powerful wizard and a member of the Fairy Tail guild, Erza possesses the ability to change her armor and weapons at will using the magic of Requip.", 1, "Erza Scarlet", "/images/erza.jpg", "Requip: The Knight", "Fairy Tail" },
                    { 16, "A delinquent who becomes a Spirit Detective and fights to protect the human world from demons and other supernatural threats, Yusuke possesses the ability to shoot a powerful blast of spirit energy called the Spirit Gun.", 1, "Yusuke Urameshi", "/images/yusuke.jpg", "Spirit Gun", "Yu Yu Hakusho" },
                    { 17, "A former assassin who becomes a wandering swordsman and vows to never kill again, Kenshin is a master of the Hiten Mitsurugi-ryu sword style and uses his skills to protect the innocent.", 1, "Kenshin Himura", "/images/kenshin.jpg", "Hiten Mitsurugi-ryu", "Rurouni Kenshin" },
                    { 18, "A bounty hunter and a former member of a criminal syndicate, Spike is a skilled marksman and a master of hand-to-hand combat. He travels the galaxy with his crew aboard the spaceship Bebop, chasing down the galaxy's most dangerous criminals.", 1, "Spike Spiegel", "/images/spike.jpg", "Marksmanship", "Cowboy Bebop" },
                    { 19, "A high school student who possesses the Millennium Puzzle, Yugi is able to summon powerful monsters to do battle in the shadow realm. He and his friends play a card game called Duel Monsters, which becomes the source of many of their adventures.", 1, "Yugi Mutou", "/images/yugi.jpg", "The Millennium Puzzle", "Yu-Gi-Oh!" },
                    { 20, "A high school student who unknowingly possesses the power to warpreality, Haruhi forms a club with her classmates to search for supernatural beings and phenomena. She is a charismatic and eccentric character who often gets herself and her friends into unusual situations.", 1, "Haruhi Suzumiya", "/images/haruhi.jpg", "Reality Warping", "The Melancholy of Haruhi Suzumiya" },
                    { 21, "A young man who possesses the ability to transform into a Titan, Eren fights to protect humanity from the Titans and uncover the secrets of his own past.", 1, "Eren Yeager", "/images/eren.jpg", "Titan Shifter", "Attack on Titan" },
                    { 22, "A powerful vampire who serves the Hellsing organization, Alucard is a skilled fighter and marksman who uses his supernatural abilities to hunt down and destroy other vampires and supernatural threats.", 1, "Alucard", "/images/alucard.jpg", "Vampire", "Hellsing" },
                    { 23, "A college student who becomes a half-ghoul after a chance encounter with a beautiful woman, Ken struggles to come to terms with his new identity and fights to protect himself and his loved ones from other ghouls and the humans who hunt them.", 1, "Ken Kaneki", "/images/kaneki.jpg", "Ghoul", "Tokyo Ghoul" },
                    { 24, "A member of the Fairy Tail guild and a Dragon Slayer who can manipulate fire, Natsu is a hot-headed and impulsive fighter who always fights for his friends and guildmates.", 1, "Natsu Dragneel", "/images/natsu.jpg", "Dragon Slayer Magic", "Fairy Tail" },
                    { 25, "A young swordsman who joins the Night Raid rebel group, Tatsumi possesses the power of the Incursio armor, which gives him superhuman strength and speed in battle.", 1, "Tatsumi", "/images/tatsumi.jpg", "Incursio", "Akame ga Kill!" },
                    { 26, "A high school student who is taken over by a parasitic alien, Shinichi fights to protect himself and his loved ones from other parasites who seek to take over the world.", 1, "Shinichi Izumi", "/images/shinichi.jpg", "Parasite", "Parasyte" },
                    { 27, "A C-Class hero who rides a bicycle and wears a homemade costume, Mumen Rider has no superpowers but is determined to protect the citizens of his city and fight for justice.", 1, "Gonpachi", "/images/mumenrider.jpg", "None", "One Punch Man" },
                    { 28, "A member of the Hyuga clan who possesses the Byakugan, a powerful eye technique, Hinata is a skilled ninja who overcomes her shyness and fights to protect her friends and loved ones.", 1, "Hinata Hyuga", "/images/hinata.jpg", "Byakugan", "Naruto" },
                    { 29, "A young boy who dreams of becoming a Hunter like his father, Gon possesses the power of Nen and sets out on a journey to find his father and become a great Hunter himself.", 1, "Gon Freecss", "/images/gon.jpg", "Nen", "Hunter x Hunter" },
                    { 30, "A self-proclaimed mad scientist who accidentally discovers the ability to send text messages to the past, Okabe and his friends must navigate the dangers of time travel and the consequences of their actions.", 1, "Rintaro Okabe", "/images/okabe.jpg", "Time travel", "Steins;Gate" },
                    { 31, "A pirate and the captain of the Straw Hat Pirates, Luffy possesses the power of the Gomu Gomu no Mi fruit, which gives him rubber-like abilities and allows him to stretch his body in various ways.", 1, "Monkey D. Luffy", "/images/luffy.jpg", "Gomu Gomu no Mi", "One Piece" },
                    { 32, "A high school student who possesses a sentient uniform named Senketsu, Ryuko fights against the mysterious organization known as Honnouji Academy and their student council president, Satsuki Kiryuin.", 1, "Ryuko Matoi", "/images/ryuko.jpg", "Senketsu", "Kill la Kill" },
                    { 33, "A superhero who can defeat any opponent with a single punch, Saitama is bored with his seemingly endless strength and searches for a worthy opponent.", 1, "Saitama", "/images/saitama.jpg", "Superhuman strength and speed", "One Punch Man" },
                    { 34, "A meister who attends the Death Weapon Meister Academy, Maka possesses the ability to sense the souls of others and uses this ability to help her weapon partner, Soul Eater, collect the souls of evil beings.", 1, "Maka Albarn", "/images/maka.jpg", "Soul Perception", "Soul Eater" },
                    { 35, "A high school student who travels back in time to the feudal era, Kagome possesses the Sacred Jewel and teams up with the half-demon Inuyasha to recover the jewel fragments and prevent evil demons from obtaining its power.", 1, "Kagome Higurashi", "/images/kagome.jpg", "Sacred Jewel", "Inuyasha" },
                    { 36, "A young alchemist who lost his arm and leg in an attempt to bring his mother back to life, Edward and his brother Alphonse search for the Philosopher's Stone in order to restore their bodies.", 1, "Edward Elric", "/images/edward.jpg", "Alchemy", "Fullmetal Alchemist" },
                    { 37, "A young girl who accidentally releases the Clow Cards and must capture them all in order to prevent their destructive power from harming the world, Sakura is a cheerful and determined character who grows stronger as she faces new challenges.", 1, "Sakura Kinomoto", "/images/sakura.jpg", "Clow Cards", "Cardcaptor Sakura" },
                    { 38, "A young chef who attends the prestigious Totsuki Saryo Culinary Institute, Soma uses his creative and unorthodox cooking style to win battles against other talented chefs and rise to the top of the school's hierarchy.", 1, "Yukihira Soma", "/images/soma.jpg", "Culinary skills", "Food Wars!" },
                    { 39, "A young boy who becomes a demon slayer after his family is killed by demons, Tanjirou trains to master the art of Breathing techniques and fights to protect humanity from the demon threat.", 1, "Tanjirou Kamado", "/images/tanjirou.jpg", "Breathing techniques", "Demon Slayer" }
                });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Description", "Gender", "Name", "PhotoPath", "Power", "Series" },
                values: new object[,]
                {
                    { 40, "A minor god who grants wishes for a fee, Yato struggles to gain followers and establish his own shrine. He teams up with a human girl named Hiyori and a regalia named Yukine to complete various tasks and earn money.", 1, "Yato", "/images/yato.jpg", "God", "Noragami" },
                    { 41, "A man who is reincarnated as a slime in a fantasy world, Rimuru gains the ability to absorb other creatures and their abilities. He builds a nation of monsters and allies with various factions to protect his people and make peace with humans.", 0, "Rimuru Tempest", "/images/rimuru.jpg", "Absorption", "That Time I Got Reincarnated as a Slime" },
                    { 42, "A strange creature with a smiling face and tentacles, Koro-sensei is a powerful being who threatens to destroy the Earth. He becomes a teacher for a class of misfit students and teaches them various skills while they try to assassinate him.", 0, "Koro-sensei", "/images/korosensei.jpg", "Tentacles", "Assassination Classroom" },
                    { 43, "An orphan who is adopted by Eren's family, Mikasa becomes a skilled fighter and joins the Survey Corps to avenge her family and protect humanity from the Titans. She wields the omni-directional mobility gear, which allows her to move freely in the air and attack Titans from any direction.", 1, "Mikasa Ackerman", "/images/mikasa.jpg", "Omnidirectional Mobility Gear", "Attack on Titan" },
                    { 44, "A former assassin who has sworn not to kill again, Kenshin becomes a wanderer and helps people in need. He wields a reverse-bladed sword and uses the Hiten Mitsurugi-ryu style, which emphasizes speed and agility in combat.", 1, "Kenshin Himura", "/images/kenshin.jpg", "Hiten Mitsurugi-ryu", "Rurouni Kenshin" },
                    { 45, "A mercenary and former member of the Band of the Hawk, Guts wields a massive sword called the Dragon Slayer and is known for his incredible strength and endurance. He seeks revenge against his former friend and leader, Griffith, who betrayed him and caused the deaths of his comrades.", 1, "Guts", "/images/guts.jpg", "Dragon Slayer", "Berserk" },
                    { 46, "A member of the Lagoon Company, a group of pirates and smugglers, Revy is a skilled gunman who is feared by many. She has a troubled past and a short temper, but also has a softer side that she rarely shows.", 1, "Revy", "/images/revy.jpg", "Firearms", "Black Lagoon" },
                    { 47, "A delinquent who dies saving a child from a car accident, Yusuke becomes a spirit detective and fights against various supernatural threats. He wields the Spirit Gun, a powerful blast of energy that he fires from his index finger.", 1, "Yusuke Urameshi", "/images/yusuke.jpg", "Spirit Gun", "Yu Yu Hakusho" },
                    { 48, "A wild and unpredictable swordsman, Mugen is a former pirate who teams up with a samurai named Jin anda young girl named Fuu to search for the", 1, "Mugen", "/images/mugen.jpg", "Swordsmanship", "Samurai Champloo" },
                    { 49, "A superhero who has become bored with his lack of challenge, Saitama gains immense strength and the ability to defeat any opponent with a single punch. He joins the Hero Association and becomes a mentor to a young cyborg named Genos.", 1, "Saitama", "/images/saitama.jpg", "One-Punch", "One-Punch Man" },
                    { 50, "A young boy who sets out to become a Hunter like his father, Gon has incredible strength and agility, as well as the ability to use Nen, a powerful technique that allows him to manipulate his life energy. He befriends several other aspiring Hunters, including Killua and Leorio.", 1, "Gon Freecss", "/images/gon.jpg", "Nen", "Hunter x Hunter" },
                    { 51, "A normal college student who becomes a half-ghoul after being attacked by one, Kaneki struggles to come to terms with his new identity and the violence that comes with it. He becomes involved in a war between humans and ghouls, and must navigate a complex web of alliances and betrayals.", 1, "Kaneki Ken", "/images/kaneki.jpg", "Ghoul", "Tokyo Ghoul" },
                    { 52, "A pirate and the captain of the Straw Hat Pirates, Luffy gains the ability to stretch his body like rubber after eating a Devil Fruit. He sets out to find the legendary treasure known as One Piece and become the Pirate King, and makes many friends and enemies along the way.", 1, "Monkey D. Luffy", "/images/luffy.jpg", "Rubber", "One Piece" },
                    { 53, "A young alchemist who lost his arm and leg in a failed attempt to bring his mother back to life, Edward sets out with his brother Alphonse to find the Philosopher's Stone, which they believe will allow them to restore their bodies. He is known as the Fullmetal Alchemist due to his automail limbs.", 1, "Edward Elric", "/images/edward.jpg", "Alchemy", "Fullmetal Alchemist" },
                    { 54, "A bounty hunter and former member of the Red Dragon Crime Syndicate, Spike is a skilled fighter and marksman who travels the galaxy with his partner Jet Black in search of the galaxy's most dangerous criminals. He has a troubled past and a love for jazz music.", 1, "Spike Spiegel", "/images/spike.jpg", "Hand-to-Hand Combat", "Cowboy Bebop" },
                    { 55, "A skilled marksman and loyal subordinate of Colonel Roy Mustang, Riza is a member of the military and serves as Mustang's personal assistant and bodyguard. She has a deep commitment to her duties and a troubled past involving her father, who was also a sharpshooter.", 1, "Riza Hawkeye", "/images/riza.jpg", "Marksmanship", "Fullmetal Alchemist" },
                    { 56, "A mysterious girl who serves as the student council president in a purgatory-like afterlife, Kanade is known as Angel due to her supernatural abilities and the fact that she is the only one who can grant the wishes of the students. She develops a connection with the main character, Otonashi, and helps him come to terms with his past.", 1, "Kanade Tachibana", "/images/kanade.jpg", "Angel", "Angel Beats!" },
                    { 57, "A high school student who is infected by a parasite named Migi, Shinichi gains superhuman abilities and finds himself caught in a war between humans and parasites. He develops a complex relationship with Migi as they work together to survive and protect their loved ones.", 1, "Shinichi Izumi", "/images/shinichi.jpg", "Migi", "Parasyte" },
                    { 58, "A member of the Phantom Thieves, a group of high school students who use their supernatural powers to steal the hearts of corrupt adults, Yusuke is a talented artist who discovers his abilities as a Persona user. He struggles to find his place in the world and comes to terms with his complicated family history.", 1, "Yusuke Kitagawa", "/images/yusukekitagawa.jpg", "Persona", "Persona 5" },
                    { 59, "A young girl who discovers a set of magical Clow Cards, Sakura becomes a Cardcaptor and must capture the cards before they cause harm to the world. She has a kind heart and a strong sense of justice, and develops a crush on her friend Syaoran.", 1, "Sakura Kinomoto", "/images/sakura.jpg", "Clow Cards", "Cardcaptor Sakura" },
                    { 60, "A shut-in who dies and is reincarnated in a fantasy world, Kazuma forms a party with a goddess, a mage, and a crusader to defeat the Demon King. He has low stats and relies on his luck and cunning to survive, often getting into comedic and dangerous situations.", 1, "Kazuma Satou", "/images/kazuma.jpg", "Luck", "KonoSuba" },
                    { 61, "A prince who is exiled and gains the power of Geass, which allows him to control people's minds, Lelouch becomes the leader of the rebellion against his father's empire. He is a brilliant strategist and charismatic leader, but his thirst for revenge and desire for power drive him to make questionable decisions.", 1, "Lelouch Lamperouge", "/images/lelouch.jpg", "Geass", "Code Geass" },
                    { 62, "A talented chef who dreams of surpassing his father's skills, Soma enrolls in a prestigious culinary school and competes in various cooking battles. He has a fearless attitude and a creative approach to cooking, often incorporating unusual ingredients and techniques.", 1, "Soma Yukihira", "/images/soma.jpg", "Cooking", "Food Wars!" },
                    { 63, "A high school student who seeks revenge for her father's death, Ryuko discovers a powerful uniform called Kamui that enhances her abilities and grants her superhuman strength and speed. She battles against the student council of her school, which is secretly controlled by her mother.", 1, "Ryuko Matoi", "/images/ryuko.jpg", "Kamui", "Kill la Kill" },
                    { 64, "A high school student who becomes involved with various supernatural beings, Koyomi gains the ability to regenerate any part of his body after being turned into a vampire. He helps various girls with their supernatural problems, often getting into dangerous situations and relying on his wit and charm to get out of them.", 1, "Koyomi Araragi", "/images/araragi.jpg", "Regeneration", "Monogatari Series" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Heros");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
