using Domain.ValueObjects;

namespace Domain.Users.Events
{
    public record UserDeactivatedEvent : UserEvent
    {
        public UserDeactivatedEvent(UpdatedByUser deactivatedBy, DateTime dateUpdated) : base(dateUpdated)
        {
            this.DeactivatedBy = deactivatedBy;
        }
        public bool IsActivated { get { return false; } }
        public UpdatedByUser DeactivatedBy { get; private set; }
    }
}
