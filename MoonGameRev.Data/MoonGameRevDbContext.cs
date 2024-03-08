namespace MoonGameRev.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MoonGameRev.Data.Models;
    using System.Reflection;

    public class MoonGameRevDbContext : IdentityDbContext
    {
        public MoonGameRevDbContext(DbContextOptions<MoonGameRevDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<GameGenre> GameGenres { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MoonGameRevDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}
