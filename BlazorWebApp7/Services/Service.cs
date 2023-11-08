using Presentation.Modules;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebApp7.Services
{
    public sealed class Service : IService
    {
        private readonly HttpClient _httpClient;
        public Service(HttpClient httpClient)
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
