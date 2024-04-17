using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoonGameRev.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGameRev.Data.Configurations
{
    public class SeedReviewsEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(this.GenerateReviews());
        }

        private IEnumerable<Review> GenerateReviews()
        {
            var reviews = new List<Review>();

            reviews.AddRange(new[]
            {
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Rating = 9.5,
                    Pros = "Hard game; Beautiful game; Addicting game",
                    Cons = "Nothing",
                    Comment = "I am absolutely thrilled with this game and can recommend it to every Souls fan. If you want to take on a new challenge and get involved in a huge world, Elden Ring is absolutely the right game for you.",
                    ReviewDate = DateTime.Now,
                    GameID = Guid.Parse("6a1c7f48-d1c9-41d9-a638-2aa7fbb1db53"),
                    UserId = Guid.Parse("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Rating = 9,
                    Pros = "Amazing attention to detail; Beautiful graphics; Makes you feel like a real cowboy",
                    Cons = "Online part is kinda bad",
                    Comment = "Amazing game definitely buy it if you got the money its well worth it. The atmosphere the game has is truly amazing and it deserves all the love in the world, at first i didnt like it much but as story kept going i just fell in love with it.",
                    ReviewDate = DateTime.Now,
                    GameID = Guid.Parse("8f6e6a53-b537-458d-8cbb-407fc01f7da9"),
                    UserId = Guid.Parse("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45"),
                },
            });

            return reviews;
        }
    }
}
