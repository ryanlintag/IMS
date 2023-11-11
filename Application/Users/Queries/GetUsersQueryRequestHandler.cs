using Domain.Users;
using Domain.ValueObjects;
using Mediator;

namespace Application.Users.Queries
{
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
