using Application.Repositories;
using Domain.Abstractions;
using Domain.Users;
using Domain.Users.Events;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
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

        public async Task Update(User user)
        {
            this._dbContext.Entry<User>(user).State = EntityState.Modified;

            var userUpdatedEvent = new UserDetailsUpdatedEvent(
                                                    user.Email.Address,
                                                    user.Name.FirstName,
                                                    user.Name.LastName,
                                                    user.Name.MiddleName,
                                                    user.Role.Name,
                                                    user.IsActive,
                                                    user.UpdatedByUser.Email.Address,
                                                    user.DateLastUpdated);

            var lastVersion = await this._dbContext.UserEvents.Where(p => p.StreamId == user.Id).MaxAsync(p => p.Version);

            var userEvent = new UserDomainEvent(new UserDomainId(Guid.NewGuid()), user.Id, lastVersion + 1, userUpdatedEvent);
            await this._dbContext.UserEvents.AddAsync(userEvent);
        }

        public bool UserExists(string address)
        {
            return this._dbContext.Users.Any(p => p.Email.Address == address);
        }

        public async Task<User> GetUserById(UserId userId)
        {
            return await this._dbContext.Users.FirstOrDefaultAsync(p => p.Id == userId);
        }

        public async Task<User> GetUserByEmail(Email email)
        {
            return await this._dbContext.Users.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
