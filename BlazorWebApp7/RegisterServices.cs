using BlazorWebApp7.Services;

namespace BlazorWebApp7
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterHttpClientServices(this IServiceCollection services) 
        {
            services.AddHttpClient<IService, Service>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7272/");
            });
            return services;
        }
    }
}
