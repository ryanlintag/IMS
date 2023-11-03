using Domain.Abstractions;

namespace Domain.Users
{
    public class User : AggregateRoot<UserId>
    {
        private User() { }

    }
}
