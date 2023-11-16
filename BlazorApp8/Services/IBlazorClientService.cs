using Application;
using Application.Users.Queries;

namespace BlazorApp8.Services
{
    public interface IBlazorClientService

    {
        Task<PagedList<UserRecord>> GetService();
    }
}
