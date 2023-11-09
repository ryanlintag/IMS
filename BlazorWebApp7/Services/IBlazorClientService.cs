using Application;
using Application.Users.Queries;
using Presentation.Modules;

namespace BlazorWebApp7.Services
{
    public interface IBlazorClientService

    {
        Task<PagedList<UserRecord>> GetService();
    }
}
