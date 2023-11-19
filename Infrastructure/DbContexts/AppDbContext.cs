using Domain.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DbContexts
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(p =>
            {
                p.ComplexProperty(o => o.UpdatedByUser, r => { r.ComplexProperty(s => s.Email); });
                p.ComplexProperty(o => o.Email);
                p.ComplexProperty(o => o.Name);
                p.ComplexProperty(o => o.Role);
            });
            modelBuilder.Entity<User>()
                .OwnsOne(p => p.UserDetails, r => {
                    r.OwnsMany(v => v.Events);
                    r.ToJson();
                });
            modelBuilder.Entity<UpdatedByUser>().ComplexProperty(p => p.Email);
            // //modelBuilder.Entity<User>().HasOne(p => p.UpdatedByUser);
            modelBuilder.Entity<UpdatedByUser>().HasNoKey();
            //modelBuilder.Entity<UserDetails>(p =>
            //{
            //    p.ComplexProperty(o => o.CreatedBy);
            //});
            // //modelBuilder.Entity<User>().HasOne(p => p.Email);
            // modelBuilder.Entity<Email>().HasNoKey();
            //// modelBuilder.Entity<User>().HasOne(p => p.Role);
            // modelBuilder.Entity<Role>().HasNoKey();
            // //modelBuilder.Entity<User>().HasOne(p => p.Name);
            // modelBuilder.Entity<Name>().HasNoKey();
            // base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
