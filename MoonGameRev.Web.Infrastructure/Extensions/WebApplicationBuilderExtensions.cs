namespace MoonGameRev.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using MoonGameRev.Data.Models;
    using System.Reflection;
    using static MoonGameRev.Common.GeneralApplicationConstants;


    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The assembly is taken from the type of random service interface or implementation provided.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] implementationTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException(
                        $"No interface is provided for the service with name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }
        }

        /// <summary>
        /// This method seeds admin role if it does not exist.
        /// Passed email should be valid email of existing user in the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string adminEmail)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                // Check if admin role exists, if not, create it
                if (!await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    IdentityRole<Guid> adminRole = new IdentityRole<Guid>(AdminRoleName);
                    await roleManager.CreateAsync(adminRole);
                }

                // Check if moderator role exists, if not, create it
                if (!await roleManager.RoleExistsAsync(ModeratorRoleName))
                {
                    IdentityRole<Guid> moderatorRole = new IdentityRole<Guid>(ModeratorRoleName);
                    await roleManager.CreateAsync(moderatorRole);
                }

                // Find the admin user by email
                AppUser adminUser = await userManager.FindByEmailAsync(adminEmail);

                // If the admin user exists, assign it to the admin role
                if (adminUser != null)
                {
                    await userManager.AddToRoleAsync(adminUser, AdminRoleName);
                }
            }).GetAwaiter().GetResult();

            return app;
        }

    }
}
