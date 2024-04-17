using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoonGameRev.Data.Models;
namespace MoonGameRev.Data.Configurations
{
    public class SeedNewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasData(this.GenerateNews());
        }

        private IEnumerable<News> GenerateNews()
        {
            var news = new List<News>();

            news.AddRange(new[]
            {
                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "Exciting New Gameplay Revealed for 'Horizon Forbidden West",
                    Article = " The highly anticipated sequel to Horizon Zero Dawn, titled Horizon Forbidden West, " +
                    "has just released new gameplay footage showcasing stunning visuals and thrilling action. Players can " +
                    "expect to explore a vast open world filled with diverse environments, encounter majestic robotic creatures," +
                    " and uncover the mysteries of a post-apocalyptic landscape. With enhanced graphics and improved gameplay mechanics, " +
                    "Horizon Forbidden West promises to deliver an unforgettable gaming experience for fans of the series.",
                    Date = DateTime.Now,
                    PictureUrl = "https://gaming-cdn.com/images/products/6202/616x353/horizon-zero-dawn-complete-edition-pc-game-steam-cover.jpg?v=1709121191",
                    JournalistId = 77
                },
                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "New Expansion Announced for 'The Witcher 3: Wild Hunt",
                    Article = "CD Projekt Red has unveiled a new expansion for the critically acclaimed RPG, " +
                    "The Witcher 3: Wild Hunt. Titled Blood and Wine, this expansion introduces players to the vibrant region of Toussaint, " +
                    "known for its picturesque landscapes and rich culture. With new quests, characters, and monsters to encounter, Blood and Wine" +
                    " promises to expand upon the already immersive world of The Witcher 3 and provide players with hours of additional gameplay.",
                    Date = DateTime.Now,
                    PictureUrl = "https://gaming-cdn.com/images/products/4608/616x353/the-witcher-3-wild-hunt-blood-and-wine-xbox-one-xbox-series-x-s-xbox-one-xbox-series-x-s-game-microsoft-store-europe-cover.jpg?v=1704208911",
                    JournalistId = 77
                },
                new News
                {
                    Id = Guid.NewGuid(),
                    Title = "Upcoming Release: 'Elden Ring' DLC Launch Date Confirmed",
                    Article = " FromSoftware's highly anticipated action RPG, Elden Ring," +
                    " finally has a confirmed launch date. Set to release on 06/21/2024, Elden Ring takes players on" +
                    " an epic journey through a vast and mysterious world created in collaboration with acclaimed author" +
                    " George R.R. Martin. With its challenging combat, intricate world-building, and dark fantasy setting, Elden Ring" +
                    " is shaping up to be one of the most anticipated releases of the year. Fans can't wait to dive into this immersive" +
                    " experience and uncover the secrets of the Elden Ring.",
                    Date = DateTime.Now,
                    PictureUrl = "https://gaming-cdn.com/images/products/16007/616x353/elden-ring-shadow-of-the-erdtree-edition-shadow-of-the-erdtree-edition-pc-game-steam-europe-cover.jpg?v=1709224367",
                    JournalistId = 77
                }
            });

            return news;
        }
    }
}
