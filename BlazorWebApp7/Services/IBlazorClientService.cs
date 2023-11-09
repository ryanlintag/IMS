using Presentation.Modules;

namespace BlazorWebApp7.Services
{
    public interface IBlazorClientService

    {
        Task<IEnumerable<WeatherForecast>> GetService();
    }
}
