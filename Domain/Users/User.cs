using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Users
{
    public class User : AggregateRoot<UserId>
    {
        public User(UserId userId, Email email, Name name, Role role, bool isActive)
        {
            this.Id = userId;
            this.Email = email;
            this.Name = name;
            this.Role = role;
            this.IsActive = isActive;
        }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public Role Role { get; private set; }
        public bool IsActive { get; private set; }
        #pragma warning disable CS8618
        private User() { }
        #pragma warning restore CS8618
    }
}
