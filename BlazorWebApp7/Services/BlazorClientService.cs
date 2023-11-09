using Presentation.Modules;

namespace BlazorWebApp7.Services
{
    public sealed class BlazorClientService : IBlazorClientService
    {
        private readonly HttpClient _httpClient;
        public BlazorClientService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<WeatherForecast>> GetService()
        {
            var l = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("users");
            if (l == null)
            {
                return new List<WeatherForecast>();
            }
            return l;
        }
    }
}
