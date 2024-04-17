using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoonGameRev.Data.Models;

namespace MoonGameRev.Data.Configurations
{
    public class SeedGamesEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(this.GenerateGames());
        }

        private IEnumerable<Game> GenerateGames()
        {
            var games = new List<Game>();

            games.AddRange(new[]
            {
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "The Witcher 3: Wild Hunt",
                                Description = "An action RPG game developed and published by CD Projekt.",
                                Developer = "CD Projekt Red",
                                Publisher = "CD Projekt",
                                GameSite = "https://thewitcher.com/",
                                ReleaseDate = new DateTime(2015, 5, 19),
                                CoverImage = "https://gaming-cdn.com/images/products/1497/616x353/the-witcher-3-wild-hunt-game-of-the-year-edition-goty-edition-pc-game-gog-com-cover.jpg?v=1670929985",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.Parse("8f6e6a53-b537-458d-8cbb-407fc01f7da9"),
                                Title = "Red Dead Redemption 2",
                                Description = "An action-adventure game developed and published by Rockstar Games.",
                                Developer = "Rockstar Games",
                                Publisher = "Rockstar Games",
                                GameSite = "https://www.rockstargames.com/reddeadredemption2/",
                                ReleaseDate = new DateTime(2018, 10, 26),
                                CoverImage = "https://gaming-cdn.com/images/products/5679/616x353/red-dead-redemption-2-pc-game-rockstar-cover.jpg?v=1701275002",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Cyberpunk 2077",
                                Description = "An open-world action-adventure game developed and published by CD Projekt.",
                                Developer = "CD Projekt Red",
                                Publisher = "CD Projekt",
                                GameSite = "https://www.cyberpunk.net/",
                                ReleaseDate = new DateTime(2020, 12, 10),
                                CoverImage = "https://gaming-cdn.com/images/products/840/616x353/cyberpunk-2077-pc-game-gog-com-cover.jpg?v=1701271565",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Apex Legends",
                                Description = "Apex Legends is the award-winning, free-to-play Hero Shooter from Respawn Entertainment. Master an ever-growing roster of legendary characters with powerful abilities, and experience strategic squad play and innovative gameplay in the next evolution of Hero Shooter and Battle Royale.",
                                Developer = "Respawn",
                                Publisher = "Electronic Arts",
                                GameSite = "https://www.ea.com/games/apex-legends",
                                ReleaseDate = new DateTime(2019, 02, 04),
                                CoverImage = "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_656/b_white/f_auto/q_auto/ncom/software/switch/70010000024591/cdb89d91f73cecccdddc8b421a31af03473ffab2c790a4cd7a133d28538052f2",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.Parse("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"),
                                Title = "Elden Ring",
                                Description = "An upcoming action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment.",
                                Developer = "FromSoftware",
                                Publisher = "Bandai Namco Entertainment",
                                GameSite = "https://en.bandainamcoent.eu/elden-ring/",
                                ReleaseDate = new DateTime(2022, 02, 25),
                                CoverImage = "https://gaming-cdn.com/images/products/4824/616x353/elden-ring-pc-game-steam-europe-cover.jpg?v=1711550841",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "The Last of Us Part II",
                                Description = "An action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment.",
                                Developer = "Naughty Dog",
                                Publisher = "Sony Interactive Entertainment",
                                GameSite = "https://www.naughtydog.com/blog/the_last_of_us_part_ii",
                                ReleaseDate = new DateTime(2020, 6, 19),
                                CoverImage = "https://gaming-cdn.com/images/products/6215/616x353/the-last-of-us-part-ii-pc-game-steam-cover.jpg?v=1710171908",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Ghost of Tsushima",
                                Description = "An action-adventure game developed by Sucker Punch Productions and published by Sony Interactive Entertainment.",
                                Developer = "Sucker Punch Productions",
                                Publisher = "Sony Interactive Entertainment",
                                GameSite = "https://www.suckerpunch.com/",
                                ReleaseDate = new DateTime(2020, 7, 17),
                                CoverImage = "https://gaming-cdn.com/images/products/9686/616x353/ghost-of-tsushima-director-s-cut-ps5-director-s-cut-playstation-5-game-playstation-store-europe-cover.jpg?v=1712138768",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "God of War",
                                Description = "An action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment.",
                                Developer = "Santa Monica Studio",
                                Publisher = "Sony Interactive Entertainment",
                                GameSite = "https://www.playstation.com/en-us/games/god-of-war/",
                                ReleaseDate = new DateTime(2018, 4, 20),
                                CoverImage = "https://gaming-cdn.com/images/products/7325/616x353/god-of-war-pc-game-steam-cover.jpg?v=1683627071",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Marvel's Spider-Man: Miles Morales",
                                Description = "A follow-up to Marvel's Spider-Man, featuring Miles Morales as the main protagonist.",
                                Developer = "Insomniac Games",
                                Publisher = "Sony Interactive Entertainment",
                                GameSite = "https://insomniac.games/game/spider-man-miles-morales/",
                                ReleaseDate = new DateTime(2020, 11, 12),
                                CoverImage = "https://gaming-cdn.com/images/products/12953/616x353/marvel-s-spider-man-miles-morales-pc-game-steam-cover.jpg?v=1695136231",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Demon's Souls",
                                Description = "A remake of the 2009 PlayStation 3 game, featuring stunning graphics and improved gameplay mechanics.",
                                Developer = "Bluepoint Games",
                                Publisher = "Sony Interactive Entertainment",
                                GameSite = "https://www.playstation.com/en-us/games/demons-souls/",
                                ReleaseDate = new DateTime(2020, 11, 12),
                                CoverImage = "https://gaming-cdn.com/images/products/9600/616x353/demon-s-souls-remake-edition-remake-edition-pc-game-cover.jpg?v=1678437042",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Star Wars Jedi: Survivor",
                                Description = "The story of Cal Kestis continues in Star Wars Jedi: Survivor™, a third-person, galaxy-spanning, action-adventure game from Respawn Entertainment, developed in collaboration with Lucasfilm Games. This narratively driven, single-player title picks up 5 years after the events of Star Wars Jedi: Fallen Order™ and follows Cal’s increasingly desperate fight as the galaxy descends further into darkness. ",
                                Developer = "Electronic Arts, Respawn",
                                Publisher = "Electronic Arts",
                                GameSite = "https://www.ea.com/games/starwars/jedi/jedi-survivor",
                                ReleaseDate = new DateTime(2023, 04, 28),
                                CoverImage = "https://gaming-cdn.com/images/products/9143/616x353/star-wars-jedi-survivor-pc-game-ea-app-cover.jpg?v=1705308257",
                                IsReleased = true
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Horizon Forbidden West",
                                Description = "A sequel to Horizon Zero Dawn, set in a distant future where robotic creatures roam the earth.",
                                Developer = "Guerrilla Games",
                                Publisher = "Sony Interactive Entertainment",
                                GameSite = "https://www.guerrilla-games.com/play/horizon",
                                ReleaseDate = new DateTime(2022, 2, 18),
                                CoverImage = "https://gaming-cdn.com/images/products/15086/616x353/horizon-forbidden-west-complete-edition-complete-edition-pc-game-steam-europe-cover.jpg?v=1711041164",
                                IsReleased = true
                            },

                            //Upcoming Games

                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Star Wars Outlaws",
                                Description = "Experience the first-ever open world Star Wars game and explore distinct planets across the galaxy, both iconic and new. Risk it all as Kay Vess, an emerging scoundrel seeking freedom and the means to start a new life. Fight, steal, & outwit your way through the galaxy’s crime syndicates as you join the galaxy’s most wanted.",
                                Developer = "Massive Entertainment",
                                Publisher = "Ubisoft",
                                GameSite = "https://www.ubisoft.com/en-gb/game/star-wars/outlaws",
                                ReleaseDate = new DateTime(2024, 08, 30),
                                CoverImage = "https://gaming-cdn.com/images/products/14344/616x353/star-wars-outlaws-pc-game-cover.jpg?v=1712670300",
                                IsReleased = false
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Dragon's Dogma 2",
                                Description = "Dragon’s Dogma is a single player, narrative driven action-RPG series that challenges the players to choose their own experience – from the appearance of their Arisen, their vocation, their party, how to approach different situations and more. Now, in this long-awaited sequel, the deep, explorable fantasy world of Dragon’s Dogma 2 awaits.",
                                Developer = "CAPCOM",
                                Publisher = "CAPCOM",
                                GameSite = "https://www.dragonsdogma.com/2/en-us/",
                                ReleaseDate = new DateTime(2022, 03, 22),
                                CoverImage = "https://gaming-cdn.com/images/products/7911/616x353/dragon-s-dogma-2-pc-game-steam-europe-cover.jpg?v=1711626178",
                                IsReleased = false
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "S.T.A.L.K.E.R. 2: Heart of Chornobyl",
                                Description = "The game is a blend of first person shooter action, combined with an immersive simulation game and a horror game, all rolled into one and sent out into the world with an atmospheric open world for you to explore – if you are brave enough!",
                                Developer = "GSC Game World",
                                Publisher = "GSC Game World",
                                GameSite = "https://www.stalker2.com/en",
                                ReleaseDate = new DateTime(2024, 09, 05),
                                CoverImage = "https://gaming-cdn.com/images/products/5376/616x353/s-t-a-l-k-e-r-2-heart-of-chornobyl-pc-game-steam-europe-cover.jpg?v=1709717150",
                                IsReleased = false
                            },
                            new Game
                            {
                                Id = Guid.NewGuid(),
                                Title = "Elden Ring - Shadow of the Erdtree",
                                Description = "Winner of hundreds of accolades including The Game Awards Game of the Year and Golden Joystick Awards Ultimate Game of the Year, ELDEN RING is the acclaimed action RPG epic set in a vast, dark fantasy world. Players embark on an epic quest with the freedom to explore and adventure at their own pace.\r\n\r\nThe Shadow of the Erdtree expansion features an all-new story set in the Land of Shadow imbued with mystery, perilous dungeons, and new enemies, weapons and equipment.",
                                Developer = "FromSoftware",
                                Publisher = "BANDAI NAMCO Entertainment",
                                GameSite = "https://en.bandainamcoent.eu/elden-ring/elden-ring/shadow-of-the-erdtree",
                                ReleaseDate = new DateTime(2024, 06, 21),
                                CoverImage = "https://gaming-cdn.com/images/products/13652/616x353/elden-ring-shadow-of-the-erdtree-pc-game-steam-europe-cover.jpg?v=1709640799",
                                IsReleased = false
                            },

            });

            return games;
        }

    }
}
