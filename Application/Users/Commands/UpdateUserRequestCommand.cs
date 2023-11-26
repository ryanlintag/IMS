using Domain.Abstractions;
using Mediator;

namespace Application.Users.Commands
{
    public record UpdateUserRequestCommand(
        Guid userId,
        string email, 
        string firstName, 
        string middleName, 
        string lastName, 
        string role, 
        bool isActive,
        string updatedBy) : ICommand<DomainResult>;
}
