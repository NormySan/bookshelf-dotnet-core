using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bookshelf.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ILoggerFactory loggerFactory)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseLoggerFactory(loggerFactory);
                options.UseSqlite("Data Source=../bookshelf.sqlite");
            });

            return services;
        }
    }
}
