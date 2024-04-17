namespace MoonGameRev.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MoonGameRev.Data.Models;

    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(this.GenerateGenre());
        }

        private Genre[] GenerateGenre()
        {
            ICollection<Genre> genres = new HashSet<Genre>()
            {
                    new Genre 
                    { 
                        GenreID = 1,
                        Name = "Adventure" 
                    },
                    new Genre 
                    {
                        GenreID = 2,
                        Name = "Action" 
                    },
                    new Genre 
                    { 
                        GenreID = 3,
                        Name = "Sports" 
                    },
                    new Genre 
                    { 
                        GenreID = 4,
                        Name = "Simulation" 
                    },
                    new Genre 
                    { 
                        GenreID = 5,
                        Name = "Platformer" 
                    },
                    new Genre 
                    { 
                        GenreID = 6,
                        Name = "RPG" 
                    },
                    new Genre 
                    { 
                        GenreID = 7,
                        Name = "First-person shooter" 
                    },
                    new Genre
                    { 
                        GenreID = 8,
                        Name = "Action-adventure" 
                    },
                    new Genre 
                    { 
                        GenreID = 9,
                        Name = "Fighting"
                    },
                    new Genre 
                    { 
                        GenreID = 10,
                        Name = "Real-time strategy" 
                    },
                    new Genre 
                    { 
                        GenreID = 11,
                        Name = "Racing"
                    },
                    new Genre 
                    { 
                        GenreID = 12,
                        Name = "Puzzle"
                    },
                    new Genre 
                    { 
                        GenreID = 13,
                        Name = "Strategy game" 
                    },
                    new Genre 
                    { 
                        GenreID = 14,
                        Name = "MMO" 
                    },
                    new Genre 
                    { 
                        GenreID = 15,
                        Name = "Party" 
                    },
                    new Genre
                    {
                        GenreID = 16,
                        Name = "Action RPG" 
                    },
                    new Genre 
                    { 
                        GenreID = 17,
                        Name = "Survival" 
                    },
                    new Genre 
                    { 
                        GenreID = 18,
                        Name = "Third-Person Shooter" 
                    },
                    new Genre 
                    { 
                        GenreID = 19,
                        Name = "Casual"
                    },
                    new Genre 
                    { 
                        GenreID = 20,
                        Name = "Story-Rich" 
                    },
                    new Genre 
                    { 
                        GenreID = 21,
                        Name = "Role-Playing" 
                    },
                    new Genre 
                    {
                        GenreID = 22,
                        Name = "Building & Automation" 
                    },
                    new Genre 
                    { 
                        GenreID = 23,
                        Name = "Card & Board" 
                    },
                    new Genre 
                    { 
                        GenreID = 24,
                        Name = "Souls-Like"
                    },
                    new Genre 
                    { 
                        GenreID = 25,
                        Name = "Open World"
                    },
                    new Genre 
                    { 
                        GenreID = 26,
                        Name = "Third-Person" 
                    },
            };

            return genres.ToArray();
        }
    }
}
