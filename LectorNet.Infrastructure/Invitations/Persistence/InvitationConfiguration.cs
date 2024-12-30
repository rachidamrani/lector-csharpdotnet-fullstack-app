using LectorNet.Domain.Models.Invitation;
using LectorNet.Domain.Models.Invitations;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.Invitations.Persistence;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder
            .HasKey(i => new { i.SenderId, i.ReceiverId });

        builder
            .HasOne(i => i.Sender)
            .WithOne()
            .HasForeignKey<Invitation>(i => i.SenderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(i => i.Receiver)
            .WithOne()
            .HasForeignKey<Invitation>(i => i.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);
        
        
        builder
            .Property(i => i.Status)
            .HasConversion(
                invitationStatus => invitationStatus.Value,
                value => InvitationStatus.FromValue(value)
                );
        
        // builder
        //     .Property(i => i.CreatedAt)
        //     .HasValueGenerator<CreatedDateGenerator>();
    }
}