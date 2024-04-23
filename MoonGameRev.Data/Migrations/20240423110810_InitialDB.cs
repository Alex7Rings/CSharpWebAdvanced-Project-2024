using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the game."),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Title of the game."),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description of the game."),
                    Developer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Developer of the game."),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Publisher of the game."),
                    GameSite = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Website of the game."),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Release date of the game."),
                    CoverImage = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "URL of the game's cover image."),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false, comment: "Specifies whether the game is released or upcoming.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                },
                comment: "Represents a game.");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the genre.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the genre.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                },
                comment: "Represents a genre.");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journalists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journalists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journalists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the review."),
                    Rating = table.Column<double>(type: "float", nullable: false, comment: "Rating given by the user for the game"),
                    Pros = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The Pros of the game"),
                    Cons = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The Cons of the game"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Comment provided by the user for the review."),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time when the review was submitted."),
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Review for a game");

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => new { x.GameID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Article = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PictureUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    JournalistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Journalists_JournalistId",
                        column: x => x.JournalistId,
                        principalTable: "Journalists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("155a0639-14bd-42f0-8b55-4568ec7831f7"), 0, "631a5da3-62a6-4dfc-8c76-2eb5435dbfed", "TestJournalist@test.com", true, false, null, "TESTJOURNALIST@TEST.COM", "TESTJOURNALIST", "AQAAAAEAACcQAAAAEJzbeblnUA+rmGNfNGDGS4+6x4MdsCXENV4zL2UAM7Hs3RF6Lv0TA2m0qrIoD72Q+A==", null, false, "MB7DV4R5S6XSORGSA4OVFXGAUUEKV7RM", false, "TestJournalist" },
                    { new Guid("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45"), 0, "f73d8fc7-acd4-487b-842a-d8ad31881880", "TestUser@test.com", true, false, null, "TESTUSER@TEST.COM", "TESTUSER", "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0", null, false, "0ca5e7e7-55c8-4028-ae09-9e8ebb8d0a80", false, "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImage", "Description", "Developer", "GameSite", "IsReleased", "Publisher", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), "https://gaming-cdn.com/images/products/5376/616x353/s-t-a-l-k-e-r-2-heart-of-chornobyl-pc-game-steam-europe-cover.jpg?v=1709717150", "The game is a blend of first person shooter action, combined with an immersive simulation game and a horror game, all rolled into one and sent out into the world with an atmospheric open world for you to explore – if you are brave enough!", "GSC Game World", "https://www.stalker2.com/en", false, "GSC Game World", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.T.A.L.K.E.R. 2: Heart of Chornobyl" },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), "https://gaming-cdn.com/images/products/13652/616x353/elden-ring-shadow-of-the-erdtree-pc-game-steam-europe-cover.jpg?v=1709640799", "Winner of hundreds of accolades including The Game Awards Game of the Year and Golden Joystick Awards Ultimate Game of the Year, ELDEN RING is the acclaimed action RPG epic set in a vast, dark fantasy world. Players embark on an epic quest with the freedom to explore and adventure at their own pace.\r\n\r\nThe Shadow of the Erdtree expansion features an all-new story set in the Land of Shadow imbued with mystery, perilous dungeons, and new enemies, weapons and equipment.", "FromSoftware", "https://en.bandainamcoent.eu/elden-ring/elden-ring/shadow-of-the-erdtree", false, "BANDAI NAMCO Entertainment", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring - Shadow of the Erdtree" },
                    { new Guid("1c68c221-b25c-4cde-916d-663a937cd1ec"), "https://gaming-cdn.com/images/products/1497/616x353/the-witcher-3-wild-hunt-game-of-the-year-edition-goty-edition-pc-game-gog-com-cover.jpg?v=1670929985", "An action RPG game developed and published by CD Projekt.", "CD Projekt Red", "https://thewitcher.com/", true, "CD Projekt", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { new Guid("1f4b307b-7ca9-40d6-ba2e-53c7ce226d0a"), "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_656/b_white/f_auto/q_auto/ncom/software/switch/70010000024591/cdb89d91f73cecccdddc8b421a31af03473ffab2c790a4cd7a133d28538052f2", "Apex Legends is the award-winning, free-to-play Hero Shooter from Respawn Entertainment. Master an ever-growing roster of legendary characters with powerful abilities, and experience strategic squad play and innovative gameplay in the next evolution of Hero Shooter and Battle Royale.", "Respawn", "https://www.ea.com/games/apex-legends", true, "Electronic Arts", new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apex Legends" },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), "https://gaming-cdn.com/images/products/15086/616x353/horizon-forbidden-west-complete-edition-complete-edition-pc-game-steam-europe-cover.jpg?v=1711041164", "A sequel to Horizon Zero Dawn, set in a distant future where robotic creatures roam the earth.", "Guerrilla Games", "https://www.guerrilla-games.com/play/horizon", true, "Sony Interactive Entertainment", new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horizon Forbidden West" },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), "https://gaming-cdn.com/images/products/12953/616x353/marvel-s-spider-man-miles-morales-pc-game-steam-cover.jpg?v=1695136231", "A follow-up to Marvel's Spider-Man, featuring Miles Morales as the main protagonist.", "Insomniac Games", "https://insomniac.games/game/spider-man-miles-morales/", true, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel's Spider-Man: Miles Morales" },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), "https://gaming-cdn.com/images/products/6215/616x353/the-last-of-us-part-ii-pc-game-steam-cover.jpg?v=1710171908", "An action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment.", "Naughty Dog", "https://www.naughtydog.com/blog/the_last_of_us_part_ii", true, "Sony Interactive Entertainment", new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us Part II" },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), "https://gaming-cdn.com/images/products/7325/616x353/god-of-war-pc-game-steam-cover.jpg?v=1683627071", "An action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment.", "Santa Monica Studio", "https://www.playstation.com/en-us/games/god-of-war/", true, "Sony Interactive Entertainment", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "God of War" },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), "https://gaming-cdn.com/images/products/4824/616x353/elden-ring-pc-game-steam-europe-cover.jpg?v=1711550841", "An upcoming action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment.", "FromSoftware", "https://en.bandainamcoent.eu/elden-ring/", true, "Bandai Namco Entertainment", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring" },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), "https://gaming-cdn.com/images/products/14344/616x353/star-wars-outlaws-pc-game-cover.jpg?v=1712670300", "Experience the first-ever open world Star Wars game and explore distinct planets across the galaxy, both iconic and new. Risk it all as Kay Vess, an emerging scoundrel seeking freedom and the means to start a new life. Fight, steal, & outwit your way through the galaxy’s crime syndicates as you join the galaxy’s most wanted.", "Massive Entertainment", "https://www.ubisoft.com/en-gb/game/star-wars/outlaws", false, "Ubisoft", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Outlaws" },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), "https://gaming-cdn.com/images/products/9600/616x353/demon-s-souls-remake-edition-remake-edition-pc-game-cover.jpg?v=1678437042", "A remake of the 2009 PlayStation 3 game, featuring stunning graphics and improved gameplay mechanics.", "Bluepoint Games", "https://www.playstation.com/en-us/games/demons-souls/", true, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demon's Souls" },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), "https://gaming-cdn.com/images/products/5679/616x353/red-dead-redemption-2-pc-game-rockstar-cover.jpg?v=1701275002", "An action-adventure game developed and published by Rockstar Games.", "Rockstar Games", "https://www.rockstargames.com/reddeadredemption2/", true, "Rockstar Games", new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), "https://gaming-cdn.com/images/products/9686/616x353/ghost-of-tsushima-director-s-cut-ps5-director-s-cut-playstation-5-game-playstation-store-europe-cover.jpg?v=1712138768", "An action-adventure game developed by Sucker Punch Productions and published by Sony Interactive Entertainment.", "Sucker Punch Productions", "https://www.suckerpunch.com/", true, "Sony Interactive Entertainment", new DateTime(2020, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghost of Tsushima" },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), "https://gaming-cdn.com/images/products/840/616x353/cyberpunk-2077-pc-game-gog-com-cover.jpg?v=1701271565", "An open-world action-adventure game developed and published by CD Projekt.", "CD Projekt Red", "https://www.cyberpunk.net/", true, "CD Projekt", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), "https://gaming-cdn.com/images/products/7911/616x353/dragon-s-dogma-2-pc-game-steam-europe-cover.jpg?v=1711626178", "Dragon’s Dogma is a single player, narrative driven action-RPG series that challenges the players to choose their own experience – from the appearance of their Arisen, their vocation, their party, how to approach different situations and more. Now, in this long-awaited sequel, the deep, explorable fantasy world of Dragon’s Dogma 2 awaits.", "CAPCOM", "https://www.dragonsdogma.com/2/en-us/", false, "CAPCOM", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon's Dogma 2" },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), "https://gaming-cdn.com/images/products/9143/616x353/star-wars-jedi-survivor-pc-game-ea-app-cover.jpg?v=1705308257", "The story of Cal Kestis continues in Star Wars Jedi: Survivor™, a third-person, galaxy-spanning, action-adventure game from Respawn Entertainment, developed in collaboration with Lucasfilm Games. This narratively driven, single-player title picks up 5 years after the events of Star Wars Jedi: Fallen Order™ and follows Cal’s increasingly desperate fight as the galaxy descends further into darkness. ", "Electronic Arts, Respawn", "https://www.ea.com/games/starwars/jedi/jedi-survivor", true, "Electronic Arts", new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Jedi: Survivor" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 2, "Action" },
                    { 3, "Sports" },
                    { 4, "Simulation" },
                    { 5, "Platformer" },
                    { 6, "RPG" },
                    { 7, "First-person shooter" },
                    { 8, "Action-adventure" },
                    { 9, "Fighting" },
                    { 10, "Real-time strategy" },
                    { 11, "Racing" },
                    { 12, "Puzzle" },
                    { 13, "Strategy game" },
                    { 14, "MMO" },
                    { 15, "Party" },
                    { 16, "Action RPG" },
                    { 17, "Survival" },
                    { 18, "Third-Person Shooter" },
                    { 19, "Casual" },
                    { 20, "Story-Rich" },
                    { 21, "Role-Playing" },
                    { 22, "Building & Automation" },
                    { 23, "Card & Board" },
                    { 24, "Souls-Like" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name" },
                values: new object[] { 25, "Open World" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name" },
                values: new object[] { 26, "Third-Person" });

            migrationBuilder.InsertData(
                table: "GameGenres",
                columns: new[] { "GameID", "GenreID" },
                values: new object[,]
                {
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), 1 },
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), 2 },
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), 7 },
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), 8 },
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), 20 },
                    { new Guid("049ac5fa-2dca-4a29-9012-b226b16e92c8"), 25 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 1 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 2 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 6 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 20 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 24 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 25 },
                    { new Guid("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), 26 },
                    { new Guid("1c68c221-b25c-4cde-916d-663a937cd1ec"), 1 },
                    { new Guid("1c68c221-b25c-4cde-916d-663a937cd1ec"), 6 },
                    { new Guid("1c68c221-b25c-4cde-916d-663a937cd1ec"), 20 },
                    { new Guid("1c68c221-b25c-4cde-916d-663a937cd1ec"), 25 },
                    { new Guid("1c68c221-b25c-4cde-916d-663a937cd1ec"), 26 },
                    { new Guid("1f4b307b-7ca9-40d6-ba2e-53c7ce226d0a"), 2 },
                    { new Guid("1f4b307b-7ca9-40d6-ba2e-53c7ce226d0a"), 7 },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), 1 },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), 2 },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), 8 },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), 18 },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), 20 },
                    { new Guid("321dafc7-35e6-4542-9e43-40de53202a3e"), 26 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 1 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 2 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 6 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 8 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 20 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 25 },
                    { new Guid("3b1e7da9-595e-4613-ba01-2bc815388520"), 26 },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), 1 },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), 2 },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), 8 },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), 18 },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), 20 },
                    { new Guid("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), 26 },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 1 },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 2 },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 6 }
                });

            migrationBuilder.InsertData(
                table: "GameGenres",
                columns: new[] { "GameID", "GenreID" },
                values: new object[,]
                {
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 20 },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 24 },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 25 },
                    { new Guid("4455f3f9-6827-47f8-bd46-44018f3c61b9"), 26 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 1 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 2 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 6 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 20 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 24 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 25 },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), 26 },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), 1 },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), 2 },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), 8 },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), 18 },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), 20 },
                    { new Guid("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), 26 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 1 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 2 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 6 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 20 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 24 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 25 },
                    { new Guid("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), 26 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 1 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 2 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 8 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 18 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 20 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 25 },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), 26 },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), 1 },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), 2 },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), 8 },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), 18 },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), 20 },
                    { new Guid("a47ab3e8-26f3-42eb-853c-c478896b80c4"), 26 },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 1 },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 2 },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 6 },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 7 },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 8 }
                });

            migrationBuilder.InsertData(
                table: "GameGenres",
                columns: new[] { "GameID", "GenreID" },
                values: new object[,]
                {
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 16 },
                    { new Guid("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), 25 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 1 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 2 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 6 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 8 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 20 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 25 },
                    { new Guid("df0a4f3f-a6b7-497e-9fdb-7867720da203"), 26 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 1 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 2 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 6 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 20 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 24 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 25 },
                    { new Guid("e7631ac4-0d71-4d77-b607-94b024bccdff"), 26 }
                });

            migrationBuilder.InsertData(
                table: "Journalists",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 77, "+359881253070", new Guid("155a0639-14bd-42f0-8b55-4568ec7831f7") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "Cons", "GameID", "Pros", "Rating", "ReviewDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5e8a1503-44f6-4373-a1cb-e3d557a61195"), "Amazing game definitely buy it if you got the money its well worth it. The atmosphere the game has is truly amazing and it deserves all the love in the world, at first i didnt like it much but as story kept going i just fell in love with it.", "Online part is kinda bad", new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), "Amazing attention to detail; Beautiful graphics; Makes you feel like a real cowboy", 9.0, new DateTime(2024, 4, 23, 14, 8, 9, 800, DateTimeKind.Local).AddTicks(4503), new Guid("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45") },
                    { new Guid("b689c4c6-3f88-414f-bb1d-fd6fad330a83"), "I am absolutely thrilled with this game and can recommend it to every Souls fan. If you want to take on a new challenge and get involved in a huge world, Elden Ring is absolutely the right game for you.", "Nothing", new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), "Hard game; Beautiful game; Addicting game", 9.5, new DateTime(2024, 4, 23, 14, 8, 9, 800, DateTimeKind.Local).AddTicks(4498), new Guid("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45") }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Article", "Date", "JournalistId", "PictureUrl", "Title" },
                values: new object[] { new Guid("2776fd0f-177c-4079-b9c6-24f8981accd0"), "CD Projekt Red has unveiled a new expansion for the critically acclaimed RPG, The Witcher 3: Wild Hunt. Titled Blood and Wine, this expansion introduces players to the vibrant region of Toussaint, known for its picturesque landscapes and rich culture. With new quests, characters, and monsters to encounter, Blood and Wine promises to expand upon the already immersive world of The Witcher 3 and provide players with hours of additional gameplay.", new DateTime(2024, 4, 23, 14, 8, 9, 800, DateTimeKind.Local).AddTicks(4402), 77, "https://gaming-cdn.com/images/products/4608/616x353/the-witcher-3-wild-hunt-blood-and-wine-xbox-one-xbox-series-x-s-xbox-one-xbox-series-x-s-game-microsoft-store-europe-cover.jpg?v=1704208911", "New Expansion Announced for 'The Witcher 3: Wild Hunt" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Article", "Date", "JournalistId", "PictureUrl", "Title" },
                values: new object[] { new Guid("5801e53b-c1d6-4ec5-997c-de6783424fec"), " The highly anticipated sequel to Horizon Zero Dawn, titled Horizon Forbidden West, has just released new gameplay footage showcasing stunning visuals and thrilling action. Players can expect to explore a vast open world filled with diverse environments, encounter majestic robotic creatures, and uncover the mysteries of a post-apocalyptic landscape. With enhanced graphics and improved gameplay mechanics, Horizon Forbidden West promises to deliver an unforgettable gaming experience for fans of the series.", new DateTime(2024, 4, 23, 14, 8, 9, 800, DateTimeKind.Local).AddTicks(4375), 77, "https://gaming-cdn.com/images/products/6202/616x353/horizon-zero-dawn-complete-edition-pc-game-steam-cover.jpg?v=1709121191", "Exciting New Gameplay Revealed for 'Horizon Forbidden West" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Article", "Date", "JournalistId", "PictureUrl", "Title" },
                values: new object[] { new Guid("c5c50d0c-20a2-4939-ac3d-c96fc900d125"), " FromSoftware's highly anticipated action RPG, Elden Ring, finally has a confirmed launch date. Set to release on 06/21/2024, Elden Ring takes players on an epic journey through a vast and mysterious world created in collaboration with acclaimed author George R.R. Martin. With its challenging combat, intricate world-building, and dark fantasy setting, Elden Ring is shaping up to be one of the most anticipated releases of the year. Fans can't wait to dive into this immersive experience and uncover the secrets of the Elden Ring.", new DateTime(2024, 4, 23, 14, 8, 9, 800, DateTimeKind.Local).AddTicks(4411), 77, "https://gaming-cdn.com/images/products/16007/616x353/elden-ring-shadow-of-the-erdtree-edition-shadow-of-the-erdtree-edition-pc-game-steam-europe-cover.jpg?v=1709224367", "Upcoming Release: 'Elden Ring' DLC Launch Date Confirmed" });

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

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenreID",
                table: "GameGenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Journalists_UserId",
                table: "Journalists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_JournalistId",
                table: "News",
                column: "JournalistId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameID",
                table: "Reviews",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
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
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Journalists");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
