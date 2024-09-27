namespace UserService.Repositories
{
    public static class RepositoriesRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();

            return services;
        }
    }
}
