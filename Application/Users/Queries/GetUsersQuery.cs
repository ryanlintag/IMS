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

    public sealed class GetUsersQueryRequestHandler : IRequestHandler<GetUsersQuery, PagedList<UserRecord>>
    {
        public async ValueTask<PagedList<UserRecord>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PagedList<UserRecord> 
            {
                Items = new List<UserRecord>()
                {
                    new UserRecord(new UserId(Guid.NewGuid()), new Email("ryanlintag@yahoo.com"), new Name("Lintag", "Ryan", "dela Torre"), "test", DateTime.Now)
                },
                TotalRecordsCount = 1
            });
        }
    }
}
