using Domain.ValueObjects;

namespace Domain.Users.Events
{
    public record UserDetailsUpdatedEvent : UserEvent
    {
        public UserDetailsUpdatedEvent(Email email, Name name, Role role, bool isActive, UpdatedByUser updatedBy, DateTime dateUpdated) : base(dateUpdated)
        {
            this.Email = email;
            this.Name = name;
            this.Role = role;
            this.IsActive = isActive;
            this.UpdatedBy = updatedBy; 
        }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public Role Role { get; private set; }
        public bool IsActive { get; private set; }
        public UpdatedByUser UpdatedBy { get; private set; }
    }
}
