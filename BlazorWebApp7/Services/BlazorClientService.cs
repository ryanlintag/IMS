using Application;
using Application.Users.Queries;
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
        public async Task<PagedList<UserRecord>> GetService()
        {
            var l = await _httpClient.GetFromJsonAsync<PagedList<UserRecord>>("users");
            if (l == null)
            {
                return new PagedList<UserRecord>();
            }
            return l;
        }
    }
}
