using Application;
using Domain.Users;

namespace BlazorApp8.Services
{
    public interface IBlazorClientService

    {
        Task<PagedList<UserRecord>> GetService();
    }
}
