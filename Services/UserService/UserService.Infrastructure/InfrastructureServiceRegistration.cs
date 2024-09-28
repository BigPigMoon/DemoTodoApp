using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Database;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("ConnectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<ApplicationDbContext>();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", 5672, "/", h =>
                    {
                        h.Username("guest"); // по умолчанию
                        h.Password("guest"); // по умолчанию
                    });
                });
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
