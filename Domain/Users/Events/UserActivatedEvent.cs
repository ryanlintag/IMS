using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Users.Events
{
    public record UserActivatedEvent : UserEvent
    {
        public UserActivatedEvent(UpdatedByUser activatedBy, DateTime dateUpdated) : base(dateUpdated)
        {
            this.ActivatedBy = activatedBy;
        }
        public bool IsActivated { get { return true; } }
        public UpdatedByUser ActivatedBy { get; private set; }

    }
}
