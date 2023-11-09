using BlazorWebApp7.Services;

namespace BlazorWebApp7
{
    public static class RegisterWebAppServices
    {
        public static IServiceCollection RegisterHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            HttpClientSettings settings = new();
            configuration.GetSection(nameof(HttpClientSettings)).Bind(settings);

            //This will be the default code base for setting api
            services.AddHttpClient<IBlazorClientService, BlazorClientService>((client) =>
            {
                client.BaseAddress = new Uri(settings.BaseAddress);
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
