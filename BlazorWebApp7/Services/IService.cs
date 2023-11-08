using Presentation.Modules;

namespace BlazorWebApp7.Services
{
    public interface IService
    {
        Task<IEnumerable<WeatherForecast>> GetService();
    }
}
