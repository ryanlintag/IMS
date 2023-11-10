using BlazorWebApp7.Services;
using Presentation.Authorization;

namespace BlazorWebApp7
{
    public static class RegisterWebAppServices
    {
        public static IServiceCollection RegisterHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            HttpClientSettings settings = new();
            configuration.GetSection(nameof(HttpClientSettings)).Bind(settings);
            var apiKey = configuration.GetSection(ApiKeyConstants.AuthorizationSection).Value;

            //This will be the default code base for setting api
            services.AddHttpClient<IBlazorClientService, BlazorClientService>((client) =>
            {
                client.BaseAddress = new Uri(settings.BaseAddress);
                client.DefaultRequestHeaders.Add(ApiKeyConstants.AuthorizationHeaderName, apiKey);
            })
            .ConfigurePrimaryHttpMessageHandler(() => 
            {
                return new SocketsHttpHandler()
                {
                    PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5)
                };
            })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);
            return services;
        }
    }

    public sealed class HttpClientSettings
    {
        public string BaseAddress { get; set; } = string.Empty;
    }
}
