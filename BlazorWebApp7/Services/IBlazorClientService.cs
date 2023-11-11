using Application;
using Application.Users.Queries;

namespace BlazorWebApp7.Services
{
    public interface IBlazorClientService

    {
        Task<PagedList<UserRecord>> GetService();
    }
}
