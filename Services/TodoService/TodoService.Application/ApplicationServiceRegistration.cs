using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoService.Application.Interfaces.Services;
using TodoService.Application.Services;

namespace TodoService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ITodosService, TodosService>();

            return services;
        }
    }
}
