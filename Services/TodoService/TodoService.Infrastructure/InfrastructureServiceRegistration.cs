using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoService.Application.Interfaces.Repositories;
using TodoService.Infrastructure.Consumers;
using TodoService.Infrastructure.Database;
using TodoService.Infrastructure.Repositories;

namespace TodoService.Infrastructure;

public static class DatabaseRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("ConnectionString");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITodoRepository, TodoRepository>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserCreatedConsumer>();
            x.AddConsumer<UserDeletedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", 5672, "/", h =>
                {
                    h.Username("guest"); // по умолчанию
                    h.Password("guest"); // по умолчанию

                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
