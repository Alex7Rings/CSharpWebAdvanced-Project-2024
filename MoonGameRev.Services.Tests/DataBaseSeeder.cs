using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGameRev.Services.Tests
{
	public static class DataBaseSeeder
	{
		public static AppUser JournalistUser;
		public static Journalist Journalist;
		
		public static void SeedDataBase(MoonGameRevDbContext dbContext)
		{

			JournalistUser = new AppUser()
			{
				UserName = "TestUser",
				NormalizedUserName = "TESTUSER",
				Email = "TestUser@test.com",
				NormalizedEmail = "TESTUSER@TEST.COM",
				EmailConfirmed = true,
				PasswordHash = "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0",
				ConcurrencyStamp = "f73d8fc7-acd4-487b-842a-d8ad31881880",
				SecurityStamp = "0ca5e7e7-55c8-4028-ae09-9e8ebb8d0a80",
				TwoFactorEnabled = false,
			};

			Journalist = new Journalist()
			{
				PhoneNumber = "+359886785089",
				UserId = JournalistUser.Id // Ensure UserId is set to the unique identifier
			};

			dbContext.Users.Add(JournalistUser);
			dbContext.Journalists.Add(Journalist);

			dbContext.SaveChanges();

		}
	}
}
