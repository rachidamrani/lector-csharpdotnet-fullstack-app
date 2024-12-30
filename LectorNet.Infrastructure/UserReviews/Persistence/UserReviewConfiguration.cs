using LectorNet.Domain.Models.UsersReviews;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.UserReviews.Persistence;

public class UserReviewConfiguration : IEntityTypeConfiguration<UserReview>
{
    public void Configure(EntityTypeBuilder<UserReview> builder)
    {
        builder.HasKey(r => new { r.UserId, r.BookId });

        builder
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.Book)
            .WithMany()
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(s => s.CreatedAt).HasValueGenerator<CreatedDateGenerator>();
    }
}
