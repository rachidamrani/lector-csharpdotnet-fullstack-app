using LectorNet.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.Users.Persistence;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.Role)
            .HasConversion(
                userRole => userRole.Name,
                name => UserRole.FromName(name, true)
            );

        builder.HasData(
            new User
            {
                Id = Guid.Parse("4cccf9b3-459a-4d06-95c5-222e0451ca3a"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword("hashedPassword123"),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
    }
}