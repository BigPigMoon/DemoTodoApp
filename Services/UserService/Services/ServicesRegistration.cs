namespace UserService.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<UsersService>();

            return services;
        }
    }
}
