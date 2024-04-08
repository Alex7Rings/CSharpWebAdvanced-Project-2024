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
    public class NewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
                .HasOne(n => n.Journalist)
                .WithMany(j => j.NewsArticles)
                .HasForeignKey(n => n.JournalistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
