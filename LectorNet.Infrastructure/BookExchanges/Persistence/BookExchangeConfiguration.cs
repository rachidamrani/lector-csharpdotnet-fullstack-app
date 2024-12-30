using LectorNet.Domain.Models.BookExchanges;
using LectorNet.Infrastructure.Common.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.BookExchanges.Persistence;

public class BookExchangeConfiguration : IEntityTypeConfiguration<BookExchange>
{
    public void Configure(EntityTypeBuilder<BookExchange> builder)
    {
        builder
            .HasKey(bx => bx.Id);

        builder
            .HasOne(bx => bx.Book)
            .WithOne()
            .HasForeignKey<BookExchange>(b => b.BookId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(bx => bx.Owner)
            .WithMany()
            .HasForeignKey(bx => bx.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(bx => bx.Requester)
            .WithMany()
            .HasForeignKey(bx => bx.RequesterId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(bx => bx.Status)
            .HasConversion(
                bookExchangeStatus => bookExchangeStatus.Value,
                value => BookExchangeStatus.FromValue(value)
                );
        
        // builder
        //     .Property(bx => bx.CreatedAt)
        //     .HasValueGenerator<CreatedDateGenerator>();
    }
}