namespace MoonGameRev.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MoonGameRev.Data.Models;
    public class GameGenreEntityConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder
               .HasKey(gg => new { gg.GameID, gg.GenreID });

            builder
               .HasOne(gg => gg.Game)
               .WithMany(g => g.GameGenres)
               .HasForeignKey(gg => gg.GameID);

            builder
               .HasOne(gg => gg.Genre)
               .WithMany(g => g.GameGenres)
               .HasForeignKey(gg => gg.GenreID);

            builder
               .HasOne(gg => gg.Genre)
               .WithMany(g => g.GameGenres)
               .HasForeignKey(gg => gg.GenreID)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
