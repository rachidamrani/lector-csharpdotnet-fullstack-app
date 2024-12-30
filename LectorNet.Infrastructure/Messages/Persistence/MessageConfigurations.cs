using LectorNet.Domain.Models;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.Messages.Persistence;

public class MessageConfigurations : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        
        builder.HasKey(m => m.Id);
        
        builder
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(m => m.Receiver)
            .WithMany()
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);
        
        // builder
        //     .Property(m => m.CreatedAt)
        //     .HasValueGenerator<CreatedDateGenerator>();
    }
}