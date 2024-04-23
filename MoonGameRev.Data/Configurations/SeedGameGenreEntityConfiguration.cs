using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoonGameRev.Data.Models;

namespace MoonGameRev.Data.Configurations
{
    public class SeedGameGenreEntityConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.HasData(this.GenerateGameGenre());
        }

        private IEnumerable<GameGenre> GenerateGameGenre()
        {
            var gamesGenres = new List<GameGenre>();

            var gameGenreMap = new Dictionary<Guid, int[]>
            {
                { Guid.Parse("1c68c221-b25c-4cde-916d-663a937cd1ec"), new[] { 1, 6, 20, 25, 26 } },
                { Guid.Parse("c43a8b45-0560-4c48-8a7d-f5038aa4d841"), new[] { 1, 2, 6, 7, 8, 16, 25 } },
                { Guid.Parse("1f4b307b-7ca9-40d6-ba2e-53c7ce226d0a"), new[] { 2, 7 } },
                { Guid.Parse("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"), new[] { 1, 2, 6, 20, 24, 25, 26 } },
                { Guid.Parse("3c4ccb83-a315-4f04-b7c0-78f07450a20d"), new[] { 1, 2, 8, 18, 20, 26 } },
                { Guid.Parse("a47ab3e8-26f3-42eb-853c-c478896b80c4"), new[] { 1, 2, 8, 18, 20, 26 } },
                { Guid.Parse("4455f3f9-6827-47f8-bd46-44018f3c61b9"), new[] { 1, 2, 6, 20, 24, 25, 26 } },
                { Guid.Parse("3b1e7da9-595e-4613-ba01-2bc815388520"), new[] { 1, 2, 6, 8, 20, 25, 26 } },
                { Guid.Parse("8e09ad4c-fa18-4c37-a13b-a1ee585b34bf"), new[] { 1, 2, 6, 20, 24, 25, 26  } },
                { Guid.Parse("e7631ac4-0d71-4d77-b607-94b024bccdff"), new[] { 1, 2, 6, 20, 24, 25, 26 } },
                { Guid.Parse("321dafc7-35e6-4542-9e43-40de53202a3e"), new[] { 1, 2, 8, 18, 20, 26 } },
                { Guid.Parse("7bd08096-2bbe-4fe8-8f5d-a00d86e6c5fb"), new[] { 1, 2, 8, 18, 20, 26 } },
                { Guid.Parse("df0a4f3f-a6b7-497e-9fdb-7867720da203"), new[] { 1, 2, 6, 8, 20, 25,26 } },
                { Guid.Parse("049ac5fa-2dca-4a29-9012-b226b16e92c8"), new[] { 1, 2, 7, 8, 20, 25 } },
                { Guid.Parse("0d390f11-1a4c-477f-b72d-dc7c0c15b3ed"), new[] { 1, 2, 6, 20, 24, 25, 26 } },
                { Guid.Parse("8f6e6a53-b537-458d-8cbb-407fc01f7da9"), new[] { 1, 2, 8, 18, 20, 25, 26 } }
            };

            foreach (var kvp in gameGenreMap)
            {
                var gameId = kvp.Key;
                var genreIds = kvp.Value;

                // Generate GameGenre entries for each genre associated with the game
                foreach (var genreId in genreIds)
                {
                    gamesGenres.Add(new GameGenre
                    {
                        GameID = gameId,
                        GenreID = genreId
                    });
                }
            }

            return gamesGenres;
        }
    }
}
