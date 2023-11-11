using Domain.Users;
using Domain.ValueObjects;
using Mediator;

namespace Application.Users.Queries
{
    public sealed record GetUsersQuery(string searchValue, int pageNumber, int pageSize, string sortProperty, string sortOrder) : SearchQuery(searchValue, pageNumber, pageSize, sortProperty, sortOrder), IRequest<PagedList<UserRecord>>;
    public sealed record UserRecord
    {
        public UserId Id { get; private set; }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public string LastUpdatedBy { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public UserRecord(UserId id, Email email, Name name, string lastUpdatedBy, DateTime lastUpdatedDate)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.LastUpdatedBy = lastUpdatedBy;
            this.LastUpdatedDate = lastUpdatedDate;
        }
    }

    
}
