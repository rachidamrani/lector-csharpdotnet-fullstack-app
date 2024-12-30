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


        builder.HasData(
            new Book
            {
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                Isbn = "9780316769488",
                Genre = BookGenre.Fiction,  // Ensure BookGenre enum has appropriate value
                PublicationYear = "1951",
                PublishingHouse = "Little, Brown and Company",
                BookCoverLink = "https://example.com/catcher-in-the-rye.jpg",
                NumberOfPages = 277,
                UserId = Guid.Parse("4cccf9b3-459a-4d06-95c5-222e0451ca3a"),
                AlreadyRead = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Book
            {
                Title = "1984",
                Author = "George Orwell",
                Isbn = "9780451524935",
                Genre = BookGenre.Dystopian,
                PublicationYear = "1949",
                PublishingHouse = "Secker & Warburg",
                BookCoverLink = "https://example.com/1984.jpg",
                NumberOfPages = 328,
                UserId = Guid.Parse("4cccf9b3-459a-4d06-95c5-222e0451ca3a"),
                AlreadyRead = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Isbn = "9780061120084",
                Genre = BookGenre.Classic,
                PublicationYear = "1960",
                PublishingHouse = "J.B. Lippincott & Co.",
                BookCoverLink = "https://example.com/to-kill-a-mockingbird.jpg",
                NumberOfPages = 281,
                UserId = Guid.Parse("4cccf9b3-459a-4d06-95c5-222e0451ca3a"),
                AlreadyRead = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

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