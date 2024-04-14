using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class SeedGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImage", "Description", "Developer", "GameSite", "IsReleased", "Publisher", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("17f14caa-f88a-414c-a23a-d0a5dd54bea0"), "https://gaming-cdn.com/images/products/5679/616x353/red-dead-redemption-2-pc-game-rockstar-cover.jpg?v=1701275002", "An action-adventure game developed and published by Rockstar Games.", "Rockstar Games", "https://www.rockstargames.com/reddeadredemption2/", true, "Rockstar Games", new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { new Guid("3c3d3a42-d940-449f-b300-2e8fb03a1e1d"), "https://gaming-cdn.com/images/products/9600/616x353/demon-s-souls-remake-edition-remake-edition-pc-game-cover.jpg?v=1678437042", "A remake of the 2009 PlayStation 3 game, featuring stunning graphics and improved gameplay mechanics.", "Bluepoint Games", "https://www.playstation.com/en-us/games/demons-souls/", true, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demon's Souls" },
                    { new Guid("4886a5f3-5650-4cfa-b2e4-2629c4300791"), "https://gaming-cdn.com/images/products/4824/616x353/elden-ring-pc-game-steam-europe-cover.jpg?v=1711550841", "An upcoming action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment.", "FromSoftware", "https://en.bandainamcoent.eu/elden-ring/", true, "Bandai Namco Entertainment", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring" },
                    { new Guid("5fd8db35-d2b6-4c20-911f-36220ce63c15"), "https://gaming-cdn.com/images/products/9143/616x353/star-wars-jedi-survivor-pc-game-ea-app-cover.jpg?v=1705308257", "The story of Cal Kestis continues in Star Wars Jedi: Survivor™, a third-person, galaxy-spanning, action-adventure game from Respawn Entertainment, developed in collaboration with Lucasfilm Games. This narratively driven, single-player title picks up 5 years after the events of Star Wars Jedi: Fallen Order™ and follows Cal’s increasingly desperate fight as the galaxy descends further into darkness. ", "Electronic Arts, Respawn", "https://www.ea.com/games/starwars/jedi/jedi-survivor", true, "Electronic Arts", new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Jedi: Survivor" },
                    { new Guid("6b1572f2-19ce-4218-b6d6-6ea43fe79076"), "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_656/b_white/f_auto/q_auto/ncom/software/switch/70010000024591/cdb89d91f73cecccdddc8b421a31af03473ffab2c790a4cd7a133d28538052f2", "Apex Legends is the award-winning, free-to-play Hero Shooter from Respawn Entertainment. Master an ever-growing roster of legendary characters with powerful abilities, and experience strategic squad play and innovative gameplay in the next evolution of Hero Shooter and Battle Royale.", "Respawn", "https://www.ea.com/games/apex-legends", true, "Electronic Arts", new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apex Legends" },
                    { new Guid("732a5714-c92a-498e-b070-2f2f73ab9b54"), "https://gaming-cdn.com/images/products/7325/616x353/god-of-war-pc-game-steam-cover.jpg?v=1683627071", "An action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment.", "Santa Monica Studio", "https://www.playstation.com/en-us/games/god-of-war/", true, "Sony Interactive Entertainment", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "God of War" },
                    { new Guid("78288ba1-8c40-40f9-ac28-8dd9e1478f1d"), "https://gaming-cdn.com/images/products/9686/616x353/ghost-of-tsushima-director-s-cut-ps5-director-s-cut-playstation-5-game-playstation-store-europe-cover.jpg?v=1712138768", "An action-adventure game developed by Sucker Punch Productions and published by Sony Interactive Entertainment.", "Sucker Punch Productions", "https://www.suckerpunch.com/", true, "Sony Interactive Entertainment", new DateTime(2020, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghost of Tsushima" },
                    { new Guid("87e85407-8ca4-4692-9f98-6f6dfae20046"), "https://gaming-cdn.com/images/products/14344/616x353/star-wars-outlaws-pc-game-cover.jpg?v=1712670300", "Experience the first-ever open world Star Wars game and explore distinct planets across the galaxy, both iconic and new. Risk it all as Kay Vess, an emerging scoundrel seeking freedom and the means to start a new life. Fight, steal, & outwit your way through the galaxy’s crime syndicates as you join the galaxy’s most wanted.", "Massive Entertainment", "https://www.ubisoft.com/en-gb/game/star-wars/outlaws", false, "Ubisoft", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Outlaws" },
                    { new Guid("890ce0cb-9b2e-4be1-b6fc-538bf0ea25d1"), "https://gaming-cdn.com/images/products/840/616x353/cyberpunk-2077-pc-game-gog-com-cover.jpg?v=1701271565", "An open-world action-adventure game developed and published by CD Projekt.", "CD Projekt Red", "https://www.cyberpunk.net/", true, "CD Projekt", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { new Guid("89b8ed61-33e7-457c-bddf-86fbed59b1c4"), "https://gaming-cdn.com/images/products/13652/616x353/elden-ring-shadow-of-the-erdtree-pc-game-steam-europe-cover.jpg?v=1709640799", "Winner of hundreds of accolades including The Game Awards Game of the Year and Golden Joystick Awards Ultimate Game of the Year, ELDEN RING is the acclaimed action RPG epic set in a vast, dark fantasy world. Players embark on an epic quest with the freedom to explore and adventure at their own pace.\r\n\r\nThe Shadow of the Erdtree expansion features an all-new story set in the Land of Shadow imbued with mystery, perilous dungeons, and new enemies, weapons and equipment.", "FromSoftware", "https://en.bandainamcoent.eu/elden-ring/elden-ring/shadow-of-the-erdtree", false, "BANDAI NAMCO Entertainment", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring - Shadow of the Erdtree" },
                    { new Guid("92863144-4155-4871-81a9-bff3363ad461"), "https://gaming-cdn.com/images/products/1497/616x353/the-witcher-3-wild-hunt-game-of-the-year-edition-goty-edition-pc-game-gog-com-cover.jpg?v=1670929985", "An action RPG game developed and published by CD Projekt.", "CD Projekt Red", "https://thewitcher.com/", true, "CD Projekt", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { new Guid("a24ff642-1ca1-4957-bc61-ede8b42415d8"), "https://gaming-cdn.com/images/products/15086/616x353/horizon-forbidden-west-complete-edition-complete-edition-pc-game-steam-europe-cover.jpg?v=1711041164", "A sequel to Horizon Zero Dawn, set in a distant future where robotic creatures roam the earth.", "Guerrilla Games", "https://www.guerrilla-games.com/play/horizon", true, "Sony Interactive Entertainment", new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horizon Forbidden West" },
                    { new Guid("a2d0e120-6821-44d9-896c-5e5a156a8fe8"), "https://gaming-cdn.com/images/products/7911/616x353/dragon-s-dogma-2-pc-game-steam-europe-cover.jpg?v=1711626178", "Dragon’s Dogma is a single player, narrative driven action-RPG series that challenges the players to choose their own experience – from the appearance of their Arisen, their vocation, their party, how to approach different situations and more. Now, in this long-awaited sequel, the deep, explorable fantasy world of Dragon’s Dogma 2 awaits.", "CAPCOM", "https://www.dragonsdogma.com/2/en-us/", false, "CAPCOM", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon's Dogma 2" },
                    { new Guid("a4f5262e-e453-4a6f-86e0-ef76e9b7adac"), "https://gaming-cdn.com/images/products/12953/616x353/marvel-s-spider-man-miles-morales-pc-game-steam-cover.jpg?v=1695136231", "A follow-up to Marvel's Spider-Man, featuring Miles Morales as the main protagonist.", "Insomniac Games", "https://insomniac.games/game/spider-man-miles-morales/", true, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel's Spider-Man: Miles Morales" },
                    { new Guid("a942e348-2037-45e5-9a76-9b1686cfceb8"), "https://gaming-cdn.com/images/products/6215/616x353/the-last-of-us-part-ii-pc-game-steam-cover.jpg?v=1710171908", "An action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment.", "Naughty Dog", "https://www.naughtydog.com/blog/the_last_of_us_part_ii", true, "Sony Interactive Entertainment", new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us Part II" },
                    { new Guid("ed8ff03b-952f-48ee-91be-03da616c33c2"), "https://gaming-cdn.com/images/products/5376/616x353/s-t-a-l-k-e-r-2-heart-of-chornobyl-pc-game-steam-europe-cover.jpg?v=1709717150", "The game is a blend of first person shooter action, combined with an immersive simulation game and a horror game, all rolled into one and sent out into the world with an atmospheric open world for you to explore – if you are brave enough!", "GSC Game World", "https://www.stalker2.com/en", false, "GSC Game World", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.T.A.L.K.E.R. 2: Heart of Chornobyl" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("17f14caa-f88a-414c-a23a-d0a5dd54bea0"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("3c3d3a42-d940-449f-b300-2e8fb03a1e1d"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("4886a5f3-5650-4cfa-b2e4-2629c4300791"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("5fd8db35-d2b6-4c20-911f-36220ce63c15"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("6b1572f2-19ce-4218-b6d6-6ea43fe79076"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("732a5714-c92a-498e-b070-2f2f73ab9b54"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("78288ba1-8c40-40f9-ac28-8dd9e1478f1d"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("87e85407-8ca4-4692-9f98-6f6dfae20046"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("890ce0cb-9b2e-4be1-b6fc-538bf0ea25d1"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("89b8ed61-33e7-457c-bddf-86fbed59b1c4"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("92863144-4155-4871-81a9-bff3363ad461"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a24ff642-1ca1-4957-bc61-ede8b42415d8"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a2d0e120-6821-44d9-896c-5e5a156a8fe8"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a4f5262e-e453-4a6f-86e0-ef76e9b7adac"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a942e348-2037-45e5-9a76-9b1686cfceb8"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("ed8ff03b-952f-48ee-91be-03da616c33c2"));
        }
    }
}
