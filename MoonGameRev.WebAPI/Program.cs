using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.Infrastructure.Extensions;

namespace MoonGameRev.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MoonGameRevDbContext>(opt => opt.UseSqlServer(connectionString));

            builder.Services.AddApplicationServices(typeof(IReviewService));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup => //allows requests to be released (CORS(site protection mechanism))
            {
                setup.AddPolicy("MoonGameRev", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7195")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MoonGameRev");//allows requests to be released

            app.MapControllers();

            app.Run();
        }
    }
}
