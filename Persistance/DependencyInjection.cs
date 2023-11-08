using Microsoft.Extensions.DependencyInjection;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            return services;
        }
    }
}
