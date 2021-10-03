using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Application
{
    public static class Configure
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
