using Persistance.DbContexts;
using TestingConsoleApp;

//await using (var context = new AppDbContext(SqlLiteDatabaseSetting.SqlLiteDbContextOption))
//{
//    await context.Database.EnsureDeletedAsync();
//    await context.Database.EnsureCreatedAsync();

//    var users = TestData.CreateUsers();
//    var userEvents = TestData.UserEvents(users);

//    await context.Users.AddRangeAsync(users);
//    await context.UserEvents.AddRangeAsync(userEvents);

//    await context.SaveChangesAsync();
//}

Console.WriteLine();