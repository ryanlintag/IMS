using Domain.Abstractions;

namespace Domain.Users
{
    public record UserEvent(DateTime UpdatedDate) : IDomainEvent;
}
