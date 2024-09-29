using ApiGateway.Aggregator;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables();
            })
            .ConfigureServices(s =>
            {
                s.AddOcelot()
                    .AddSingletonDefinedAggregator<UserTodoAggregator>();

                s.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins", builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });

                    options.AddPolicy("AllowSpecificOrigin", builder =>
                    {
                        builder.WithOrigins("http://localhost:8000")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                    });
                });
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
            })
            .UseIISIntegration()
            .Configure(app =>
            {
                app.UseCors("AllowSpecificOrigin");

                app.UseOcelot().Wait();
            })
            .Build()
            .Run();