using LectorNet.Domain.Models.UsersBooksReactions;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.UserReactions.Persistence;

public class UserReactionConfiguration: IEntityTypeConfiguration<UserBookReaction>
{
    public void Configure(EntityTypeBuilder<UserBookReaction> builder)
    {
        builder
            .HasKey(r => new { r.UserId, r.BookId });
        
        builder
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(r => r.Book)
            .WithMany()
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(r => r.Reaction)
            .HasConversion(
                reactionType => reactionType.Value,
                value => ReactionType.FromValue(value)
            );
        
        // builder
        //     .Property(s => s.CreatedAt)
        //     .HasValueGenerator<CreatedDateGenerator>();
    }
}