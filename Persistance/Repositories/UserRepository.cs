using Application.Repositories;
using Domain.Abstractions;
using Domain.Users;
using Domain.Users.Events;
using Persistance.DbContexts;

namespace Persistance.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext {  get; set; }
        public UserRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task CreateNewUser(User user)
        {
            await this._dbContext.Users.AddAsync(user);
            
            var userCreatedEvent = new UserCreatedEvent(user.Id.id, 
                                                    user.Email.Address, 
                                                    user.Name.FirstName, 
                                                    user.Name.LastName, 
                                                    user.Name.MiddleName, 
                                                    user.Role.Name, 
                                                    user.UpdatedByUser.Email.Address, 
                                                    user.DateLastUpdated);

            var userEvent = new UserDomainEvent(new UserDomainId(Guid.NewGuid()), user.Id, 1, userCreatedEvent);
            await this._dbContext.UserEvents.AddAsync(userEvent);
        }

        public async Task SaveChanges()
        {
            await this._dbContext.SaveChangesAsync();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string address)
        {
            return this._dbContext.Users.Any(p => p.Email.Address == address);
        }
    }
}
