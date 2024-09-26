using Microsoft.EntityFrameworkCore;

namespace UserService.Database;

public static class DatabaseRegistration
{
    public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("UsersConnectionString");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ApplicationDbContext>();

        // TODO: Add broker

        return services;
    }
}
