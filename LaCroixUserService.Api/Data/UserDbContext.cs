using LaCroix.UserService.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaCroix.UserService.Api.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid(),
                Nickname = "admin",
                Email = "admin@admin.admin",
                PasswordHash = "$2a$12$cM50rnz.gJIlKfPwfl5gAu9zJRaZOp2cHn0cvOkQPTUwdscJ76yIG", //qwerty123
                Role = Contracts.Enums.UserRole.Admin,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                Status = Contracts.Enums.Status.Active
            });
        }
    }
}
