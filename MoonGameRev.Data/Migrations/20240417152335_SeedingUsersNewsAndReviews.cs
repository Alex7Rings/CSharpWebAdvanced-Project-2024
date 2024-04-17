using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class SeedingUsersNewsAndReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("1c0ed912-4d97-4311-9c24-a2fd5fef05df"), "https://gaming-cdn.com/images/products/840/616x353/cyberpunk-2077-pc-game-gog-com-cover.jpg?v=1701271565", "An open-world action-adventure game developed and published by CD Projekt.", "CD Projekt Red", "https://www.cyberpunk.net/", true, "CD Projekt", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { new Guid("38d0be98-0c0a-436f-a386-f674a49398c5"), "https://gaming-cdn.com/images/products/1497/616x353/the-witcher-3-wild-hunt-game-of-the-year-edition-goty-edition-pc-game-gog-com-cover.jpg?v=1670929985", "An action RPG game developed and published by CD Projekt.", "CD Projekt Red", "https://thewitcher.com/", true, "CD Projekt", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { new Guid("46a63a4d-cd15-48ea-ae42-8bebddb8b5ae"), "https://gaming-cdn.com/images/products/9600/616x353/demon-s-souls-remake-edition-remake-edition-pc-game-cover.jpg?v=1678437042", "A remake of the 2009 PlayStation 3 game, featuring stunning graphics and improved gameplay mechanics.", "Bluepoint Games", "https://www.playstation.com/en-us/games/demons-souls/", true, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demon's Souls" },
                    { new Guid("4f12ed75-3dcc-4dad-b9a4-aef49b917a07"), "https://gaming-cdn.com/images/products/5376/616x353/s-t-a-l-k-e-r-2-heart-of-chornobyl-pc-game-steam-europe-cover.jpg?v=1709717150", "The game is a blend of first person shooter action, combined with an immersive simulation game and a horror game, all rolled into one and sent out into the world with an atmospheric open world for you to explore – if you are brave enough!", "GSC Game World", "https://www.stalker2.com/en", false, "GSC Game World", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.T.A.L.K.E.R. 2: Heart of Chornobyl" },
                    { new Guid("6942a2b2-7c22-487d-88c1-e5f22fc4b081"), "https://gaming-cdn.com/images/products/15086/616x353/horizon-forbidden-west-complete-edition-complete-edition-pc-game-steam-europe-cover.jpg?v=1711041164", "A sequel to Horizon Zero Dawn, set in a distant future where robotic creatures roam the earth.", "Guerrilla Games", "https://www.guerrilla-games.com/play/horizon", true, "Sony Interactive Entertainment", new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horizon Forbidden West" },
                    { new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), "https://gaming-cdn.com/images/products/4824/616x353/elden-ring-pc-game-steam-europe-cover.jpg?v=1711550841", "An upcoming action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment.", "FromSoftware", "https://en.bandainamcoent.eu/elden-ring/", true, "Bandai Namco Entertainment", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring" },
                    { new Guid("8692a90e-b629-4893-8aa9-7c4c18a7824d"), "https://gaming-cdn.com/images/products/6215/616x353/the-last-of-us-part-ii-pc-game-steam-cover.jpg?v=1710171908", "An action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment.", "Naughty Dog", "https://www.naughtydog.com/blog/the_last_of_us_part_ii", true, "Sony Interactive Entertainment", new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us Part II" },
                    { new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), "https://gaming-cdn.com/images/products/5679/616x353/red-dead-redemption-2-pc-game-rockstar-cover.jpg?v=1701275002", "An action-adventure game developed and published by Rockstar Games.", "Rockstar Games", "https://www.rockstargames.com/reddeadredemption2/", true, "Rockstar Games", new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { new Guid("90e7a4f8-7ef8-4ee4-856d-e692c792d697"), "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_656/b_white/f_auto/q_auto/ncom/software/switch/70010000024591/cdb89d91f73cecccdddc8b421a31af03473ffab2c790a4cd7a133d28538052f2", "Apex Legends is the award-winning, free-to-play Hero Shooter from Respawn Entertainment. Master an ever-growing roster of legendary characters with powerful abilities, and experience strategic squad play and innovative gameplay in the next evolution of Hero Shooter and Battle Royale.", "Respawn", "https://www.ea.com/games/apex-legends", true, "Electronic Arts", new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apex Legends" },
                    { new Guid("a46f2eb1-0271-45bf-8bfe-0b4a30f4acbd"), "https://gaming-cdn.com/images/products/7325/616x353/god-of-war-pc-game-steam-cover.jpg?v=1683627071", "An action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment.", "Santa Monica Studio", "https://www.playstation.com/en-us/games/god-of-war/", true, "Sony Interactive Entertainment", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "God of War" },
                    { new Guid("ab635ff6-9b60-4354-a95f-15b797768383"), "https://gaming-cdn.com/images/products/12953/616x353/marvel-s-spider-man-miles-morales-pc-game-steam-cover.jpg?v=1695136231", "A follow-up to Marvel's Spider-Man, featuring Miles Morales as the main protagonist.", "Insomniac Games", "https://insomniac.games/game/spider-man-miles-morales/", true, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel's Spider-Man: Miles Morales" },
                    { new Guid("acd366d5-c22e-4d6f-9a9f-21d9c0977701"), "https://gaming-cdn.com/images/products/7911/616x353/dragon-s-dogma-2-pc-game-steam-europe-cover.jpg?v=1711626178", "Dragon’s Dogma is a single player, narrative driven action-RPG series that challenges the players to choose their own experience – from the appearance of their Arisen, their vocation, their party, how to approach different situations and more. Now, in this long-awaited sequel, the deep, explorable fantasy world of Dragon’s Dogma 2 awaits.", "CAPCOM", "https://www.dragonsdogma.com/2/en-us/", false, "CAPCOM", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon's Dogma 2" },
                    { new Guid("b58551f6-7d64-443a-8481-3f5abb776c49"), "https://gaming-cdn.com/images/products/9143/616x353/star-wars-jedi-survivor-pc-game-ea-app-cover.jpg?v=1705308257", "The story of Cal Kestis continues in Star Wars Jedi: Survivor™, a third-person, galaxy-spanning, action-adventure game from Respawn Entertainment, developed in collaboration with Lucasfilm Games. This narratively driven, single-player title picks up 5 years after the events of Star Wars Jedi: Fallen Order™ and follows Cal’s increasingly desperate fight as the galaxy descends further into darkness. ", "Electronic Arts, Respawn", "https://www.ea.com/games/starwars/jedi/jedi-survivor", true, "Electronic Arts", new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Jedi: Survivor" },
                    { new Guid("d2f09ca0-7368-499a-930c-4a91b5971a31"), "https://gaming-cdn.com/images/products/14344/616x353/star-wars-outlaws-pc-game-cover.jpg?v=1712670300", "Experience the first-ever open world Star Wars game and explore distinct planets across the galaxy, both iconic and new. Risk it all as Kay Vess, an emerging scoundrel seeking freedom and the means to start a new life. Fight, steal, & outwit your way through the galaxy’s crime syndicates as you join the galaxy’s most wanted.", "Massive Entertainment", "https://www.ubisoft.com/en-gb/game/star-wars/outlaws", false, "Ubisoft", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Outlaws" },
                    { new Guid("de6cb38e-5c9f-4802-9e4c-d72245c77b4a"), "https://gaming-cdn.com/images/products/9686/616x353/ghost-of-tsushima-director-s-cut-ps5-director-s-cut-playstation-5-game-playstation-store-europe-cover.jpg?v=1712138768", "An action-adventure game developed by Sucker Punch Productions and published by Sony Interactive Entertainment.", "Sucker Punch Productions", "https://www.suckerpunch.com/", true, "Sony Interactive Entertainment", new DateTime(2020, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghost of Tsushima" },
                    { new Guid("f6e9ff58-10e0-4c21-8015-19ee68a642af"), "https://gaming-cdn.com/images/products/13652/616x353/elden-ring-shadow-of-the-erdtree-pc-game-steam-europe-cover.jpg?v=1709640799", "Winner of hundreds of accolades including The Game Awards Game of the Year and Golden Joystick Awards Ultimate Game of the Year, ELDEN RING is the acclaimed action RPG epic set in a vast, dark fantasy world. Players embark on an epic quest with the freedom to explore and adventure at their own pace.\r\n\r\nThe Shadow of the Erdtree expansion features an all-new story set in the Land of Shadow imbued with mystery, perilous dungeons, and new enemies, weapons and equipment.", "FromSoftware", "https://en.bandainamcoent.eu/elden-ring/elden-ring/shadow-of-the-erdtree", false, "BANDAI NAMCO Entertainment", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring - Shadow of the Erdtree" }
                });

            migrationBuilder.InsertData(
                table: "Journalists",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 77, "+359881253070", new Guid("155a0639-14bd-42f0-8b55-4568ec7831f7") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "Cons", "GameID", "Pros", "Rating", "ReviewDate", "UserId" },
                values: new object[] { new Guid("39428876-6464-429f-9d2c-062df8916e99"), "Amazing game definitely buy it if you got the money its well worth it. The atmosphere the game has is truly amazing and it deserves all the love in the world, at first i didnt like it much but as story kept going i just fell in love with it.", "Online part is kinda bad", new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), "Amazing attention to detail; Beautiful graphics; Makes you feel like a real cowboy", 9.0, new DateTime(2024, 4, 17, 18, 23, 35, 13, DateTimeKind.Local).AddTicks(718), new Guid("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "Cons", "GameID", "Pros", "Rating", "ReviewDate", "UserId" },
                values: new object[] { new Guid("662426a0-ea6f-4072-8c5b-3c279be92aae"), "I am absolutely thrilled with this game and can recommend it to every Souls fan. If you want to take on a new challenge and get involved in a huge world, Elden Ring is absolutely the right game for you.", "Nothing", new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), "Hard game; Beautiful game; Addicting game", 9.5, new DateTime(2024, 4, 17, 18, 23, 35, 13, DateTimeKind.Local).AddTicks(711), new Guid("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45") });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Article", "Date", "JournalistId", "PictureUrl", "Title" },
                values: new object[] { new Guid("18f8b914-f7a8-4aef-9904-c1dd63b6ef30"), " FromSoftware's highly anticipated action RPG, Elden Ring, finally has a confirmed launch date. Set to release on 06/21/2024, Elden Ring takes players on an epic journey through a vast and mysterious world created in collaboration with acclaimed author George R.R. Martin. With its challenging combat, intricate world-building, and dark fantasy setting, Elden Ring is shaping up to be one of the most anticipated releases of the year. Fans can't wait to dive into this immersive experience and uncover the secrets of the Elden Ring.", new DateTime(2024, 4, 17, 18, 23, 35, 13, DateTimeKind.Local).AddTicks(623), 77, "https://gaming-cdn.com/images/products/16007/616x353/elden-ring-shadow-of-the-erdtree-edition-shadow-of-the-erdtree-edition-pc-game-steam-europe-cover.jpg?v=1709224367", "Upcoming Release: 'Elden Ring' DLC Launch Date Confirmed" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Article", "Date", "JournalistId", "PictureUrl", "Title" },
                values: new object[] { new Guid("8016d29c-de69-4ce8-8ed6-db3ff42a1f18"), "CD Projekt Red has unveiled a new expansion for the critically acclaimed RPG, The Witcher 3: Wild Hunt. Titled Blood and Wine, this expansion introduces players to the vibrant region of Toussaint, known for its picturesque landscapes and rich culture. With new quests, characters, and monsters to encounter, Blood and Wine promises to expand upon the already immersive world of The Witcher 3 and provide players with hours of additional gameplay.", new DateTime(2024, 4, 17, 18, 23, 35, 13, DateTimeKind.Local).AddTicks(620), 77, "https://gaming-cdn.com/images/products/4608/616x353/the-witcher-3-wild-hunt-blood-and-wine-xbox-one-xbox-series-x-s-xbox-one-xbox-series-x-s-game-microsoft-store-europe-cover.jpg?v=1704208911", "New Expansion Announced for 'The Witcher 3: Wild Hunt" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Article", "Date", "JournalistId", "PictureUrl", "Title" },
                values: new object[] { new Guid("ebdb9294-b154-4f87-9b0a-586ac3573e4d"), " The highly anticipated sequel to Horizon Zero Dawn, titled Horizon Forbidden West, has just released new gameplay footage showcasing stunning visuals and thrilling action. Players can expect to explore a vast open world filled with diverse environments, encounter majestic robotic creatures, and uncover the mysteries of a post-apocalyptic landscape. With enhanced graphics and improved gameplay mechanics, Horizon Forbidden West promises to deliver an unforgettable gaming experience for fans of the series.", new DateTime(2024, 4, 17, 18, 23, 35, 13, DateTimeKind.Local).AddTicks(589), 77, "https://gaming-cdn.com/images/products/6202/616x353/horizon-zero-dawn-complete-edition-pc-game-steam-cover.jpg?v=1709121191", "Exciting New Gameplay Revealed for 'Horizon Forbidden West" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("1c0ed912-4d97-4311-9c24-a2fd5fef05df"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("38d0be98-0c0a-436f-a386-f674a49398c5"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("46a63a4d-cd15-48ea-ae42-8bebddb8b5ae"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("4f12ed75-3dcc-4dad-b9a4-aef49b917a07"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("6942a2b2-7c22-487d-88c1-e5f22fc4b081"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("8692a90e-b629-4893-8aa9-7c4c18a7824d"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("90e7a4f8-7ef8-4ee4-856d-e692c792d697"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a46f2eb1-0271-45bf-8bfe-0b4a30f4acbd"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("ab635ff6-9b60-4354-a95f-15b797768383"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("acd366d5-c22e-4d6f-9a9f-21d9c0977701"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("b58551f6-7d64-443a-8481-3f5abb776c49"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("d2f09ca0-7368-499a-930c-4a91b5971a31"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("de6cb38e-5c9f-4802-9e4c-d72245c77b4a"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("f6e9ff58-10e0-4c21-8015-19ee68a642af"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("18f8b914-f7a8-4aef-9904-c1dd63b6ef30"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("8016d29c-de69-4ce8-8ed6-db3ff42a1f18"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("ebdb9294-b154-4f87-9b0a-586ac3573e4d"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("39428876-6464-429f-9d2c-062df8916e99"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("662426a0-ea6f-4072-8c5b-3c279be92aae"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("8f6e6a53-b537-458d-8cbb-407fc01f7da9"));

            migrationBuilder.DeleteData(
                table: "Journalists",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("155a0639-14bd-42f0-8b55-4568ec7831f7"));

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
    }
}
