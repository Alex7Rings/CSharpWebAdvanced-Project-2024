using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoonGameRev.Data.Models;

public class UserSeeder : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData(this.GenerateUsers());
    }

    private IEnumerable<AppUser> GenerateUsers()
    {
        var users = new List<AppUser>();

        users.AddRange(new[]
        {
            new AppUser
            {
                Id = Guid.Parse("e5c2f1f1-39bc-44a7-aa1a-f7ffa8d18c45"),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "TestUser@test.com",
                NormalizedEmail = "TESTUSER@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0",
                ConcurrencyStamp = "f73d8fc7-acd4-487b-842a-d8ad31881880",
                SecurityStamp = "0ca5e7e7-55c8-4028-ae09-9e8ebb8d0a80",
                TwoFactorEnabled = false,
            },
            new AppUser
            {
                Id = Guid.Parse("155a0639-14bd-42f0-8b55-4568ec7831f7"),
                UserName = "TestJournalist",
                NormalizedUserName = "TESTJOURNALIST",
                Email = "TestJournalist@test.com",
                NormalizedEmail = "TESTJOURNALIST@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJzbeblnUA+rmGNfNGDGS4+6x4MdsCXENV4zL2UAM7Hs3RF6Lv0TA2m0qrIoD72Q+A==",
                ConcurrencyStamp = "631a5da3-62a6-4dfc-8c76-2eb5435dbfed",
                SecurityStamp = "MB7DV4R5S6XSORGSA4OVFXGAUUEKV7RM",
                TwoFactorEnabled = false,
            }
        });

        return users;
    }


}