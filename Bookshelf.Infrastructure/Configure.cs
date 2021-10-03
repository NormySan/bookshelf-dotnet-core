using Bookshelf.Domain.Books;
using Bookshelf.Domain.Reviews;
using Bookshelf.Infrastructure.Domain.Books;
using Bookshelf.Infrastructure.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bookshelf.Infrastructure
{
    public static class Configure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ILoggerFactory loggerFactory)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseLoggerFactory(loggerFactory);
                options.UseSqlite("Data Source=../bookshelf.sqlite");
            });

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            return services;
        }
    }
}
