namespace MoonGameRev.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MoonGameRev.Data.Models;
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
               .HasMany(g => g.Reviews)
               .WithOne(r => r.Game)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
