using LectorNet.Domain.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LectorNet.Infrastructure.Books.Persistence;

public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);

        builder
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(book => book.Genre)
            .HasConversion(
                bookGenre => bookGenre.Name,
                name => BookGenre.FromName(name, true)
            );

        // builder.OwnsOne(book => book.TimeRange, timeRange =>
        // {
        //     timeRange.Property(t => t.Start)
        //         .HasColumnName("ReadingStartDate")
        //         .IsRequired();
        //
        //     timeRange.Property(t => t.End)
        //         .HasColumnName("ReadingEndDate")
        //         .IsRequired();
        // });

        // builder.OwnsOne(book => book.Isbn, isbn =>
        // {
        //     isbn.Property(i => i.Value)
        //         .HasColumnName("Isbn")
        //         .IsRequired();
        // });
    }
}