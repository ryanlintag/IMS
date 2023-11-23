using Domain.Users;

namespace Application.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task Update(User user);
        bool UserExists(string address);
        Task CreateNewUser(User user);
    }
}
