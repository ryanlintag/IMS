using Carter;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Authorization;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddCarter();
            return services;
        }
    }
}
