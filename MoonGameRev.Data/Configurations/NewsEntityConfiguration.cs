namespace MoonGameRev.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MoonGameRev.Data.Models;

    public class NewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
                .HasOne(n => n.Journalist)
                .WithMany(j => j.NewsArticles)
                .HasForeignKey(n => n.JournalistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(n => n.Date)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
