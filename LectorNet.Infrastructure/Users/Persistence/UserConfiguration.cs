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
    }
}