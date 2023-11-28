using Application;
using Application.Users.Queries;
using Domain.Users;

namespace BlazorApp8.Services
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
                return new PagedList<UserRecord>(new List<UserRecord>(), 1, 1, 1, "", "",new SortOrder(""));
            }
            return l;
        }

        Task<PagedList<UserRecord>> IBlazorClientService.GetService()
        {
            throw new NotImplementedException();
        }
    }
}
