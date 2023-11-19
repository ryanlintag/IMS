using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Users
{
    public class User : AggregateRoot<UserId>
    {
        public User(UserId userId, Email email, Name name, Role role, bool isActive, UpdatedByUser updatedByUser, DateTime dateLastUpdated, UserDetails userDetails)
        {
            this.Id = userId;
            this.Email = email;
            this.Name = name;
            this.Role = role;
            this.IsActive = isActive;
            this.UpdatedByUser = updatedByUser;
            this.DateLastUpdated = dateLastUpdated;
            this.UserDetails = userDetails;
        }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public Role Role { get; private set; }
        public bool IsActive { get; private set; }
        public UpdatedByUser UpdatedByUser { get; private set; }
        public DateTime DateLastUpdated { get; private set; }
        public UserDetails UserDetails { get; private set; }
        #pragma warning disable CS8618
        private User() { }
        #pragma warning restore CS8618
    }

    public class UserDetails
    {
        private UserDetails() { }
        public UserDetails(UpdatedByUser createdBy, DateTime dateCreated, List<TrackableEvent<UserEvent>> events)
        {
            this.CreatedBy = createdBy;
            this.DateCreated = dateCreated;
            this.Events = events;
        }
        public UpdatedByUser CreatedBy {  get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<TrackableEvent<UserEvent>> Events { get; private set; }    
    }
}
