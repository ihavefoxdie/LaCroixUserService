using LaCroix.UserService.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace LaCroix.UserService.Infrastructure.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nickname)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.FirstName)
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .HasMaxLength(100);

            builder.Property(u => u.Gender);

            builder.Property(u => u.Birthday);

            builder.Property(u => u.Status);

            builder.Property(u => u.Role);

            builder.Property(u => u.CreatedDate);

            // ✅ Configure Email as owned value object
            builder.Property(u => u.Email)
                   .HasConversion(email => email.Value,value => new Email(value))
                   .HasColumnName("Email")
                   .IsRequired()
                   .HasMaxLength(255);
        });
    }
}