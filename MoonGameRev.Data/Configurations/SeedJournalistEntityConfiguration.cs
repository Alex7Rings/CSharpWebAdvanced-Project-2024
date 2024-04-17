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
    public class SeedJournalistEntityConfiguration: IEntityTypeConfiguration<Journalist>
    {
        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder.HasData(this.GenerateJournalist());
        }

        private IEnumerable<Journalist> GenerateJournalist()
        {
            var journalist = new List<Journalist>();

            journalist.AddRange(new []
            {
                new Journalist 
                {
                    Id = 77,
                    PhoneNumber = "+359881253070",
                    UserId = Guid.Parse("155a0639-14bd-42f0-8b55-4568ec7831f7")
                }
            });

            return journalist;
        }
    }
}
