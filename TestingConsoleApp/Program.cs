using Infrastructure.DbContexts;

await using (var context = new AppDbContext(InMemoryDatabaseSetting.InMemoryDbContextOption))
{
    //await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
}