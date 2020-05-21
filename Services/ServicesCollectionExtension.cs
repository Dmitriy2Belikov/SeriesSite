using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeriesSite.Infrastructure;
using SeriesSite.Infrastructure.Services;
using System;

namespace SeriesSite.Services
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAppDataService, AppDataService>();
            services.AddScoped<ISeedDataService, SeedDataService>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISerialService, SerialService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
