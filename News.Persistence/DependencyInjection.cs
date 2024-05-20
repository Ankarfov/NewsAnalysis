using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Interfaces;

namespace News.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["dbConnection"];
            services.AddDbContext<NewsDbContext>(options => 
                options.UseSqlite(connectionString));

            services.AddScoped<INewsDbContext>(provider => 
                provider.GetService<NewsDbContext>());

            return services;
        }
    }
}
