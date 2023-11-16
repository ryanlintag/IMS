using Domain.Users;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task Update(User user);
        Task Crete(User user);
    }
}
