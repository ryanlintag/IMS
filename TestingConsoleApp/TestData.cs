using Domain.Users;
using Domain.Users.Events;
using Domain.ValueObjects;
using System.Text.Json;

namespace TestingConsoleApp
{
    public static class TestData
    {
        public static List<User> CreateUsers()
        {
            var userId1 = new UserId(Guid.NewGuid());
            var userId2 = new UserId(Guid.NewGuid());
            var user1 = new User(userId1,
                        new Email("ryanlintag@gmail.com"),
                        new Name("Lintag", "Ryan", null),
                        new Role(Role.Admin),
                        true,
                        new UpdatedByUser(new Email("ryanlintag@gmail.com")),
                        DateTime.UtcNow
                        );
            var user2 = new User(userId2,
                        new Email("paulablanchgarcia@gmail.com"),
                        new Name("Garcia", "Paula Blanch", "Ferrer"),
                        new Role(Role.User),
                        true,
                        new UpdatedByUser(new Email("ryanlintag@gmail.com")),
                        DateTime.UtcNow
                        );
            var users = new List<User>() 
            { 
                user1,
                user2
            };

            return users;
        }

        public static List<UserDomainEvent> UserEvents(List<User> users) 
        {
            var user1 = users[0];
            var user1CreatedEvent = new UserCreatedEvent(user1.Id.id, 
                                            user1.Email.Address, 
                                            user1.Name.FirstName, 
                                            user1.Name.LastName, 
                                            user1.Name.MiddleName, 
                                            user1.Role.Name, 
                                            user1.UpdatedByUser.Email.Address, 
                                            user1.DateLastUpdated);
            var user2 = users[1];
            var user2CreatedEvent = new UserCreatedEvent(user2.Id.id,
                                            user2.Email.Address,
                                            user2.Name.FirstName,
                                            user2.Name.LastName,
                                            user2.Name.MiddleName,
                                            user2.Role.Name,
                                            user2.UpdatedByUser.Email.Address,
                                            user2.DateLastUpdated);
            var events = new List<UserDomainEvent>()
            {
                new UserDomainEvent(new UserDomainId(Guid.NewGuid()), user1.Id, 1, user1CreatedEvent),
                new UserDomainEvent(new UserDomainId(Guid.NewGuid()), user2.Id, 1, user2CreatedEvent),
            };
            return events;
        }
    }
}
