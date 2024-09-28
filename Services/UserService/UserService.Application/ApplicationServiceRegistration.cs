using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.Interfaces;
using UserService.Application.Services;

namespace UserService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
