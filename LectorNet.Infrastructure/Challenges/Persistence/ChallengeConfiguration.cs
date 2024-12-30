using LectorNet.Domain.Models.Challenges;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.Challenges.Persistence;

public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder
            .HasOne(c => c.Book)
            .WithMany()
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(c => c.Status)
            .HasConversion(
                challengeStatus => challengeStatus.Value,
                value => ChallengeStatus.FromValue(value)
            );
        
        // builder
        //     .Property(c => c.CreatedAt)
        //     .HasValueGenerator<CreatedDateGenerator>();
    }
}