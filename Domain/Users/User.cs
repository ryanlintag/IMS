using Domain.Abstractions;

namespace Domain.Users
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
        }
        private User() { }
    }
}
