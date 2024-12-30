using LectorNet.Domain.Models.Common;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.Books;

public class Book : BaseEntity
{
    public  string Title { get; set; } = string.Empty;
    public  string Author { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public BookGenre Genre { get; set; } = BookGenre.None;
    public  string PublicationYear { get; set; } = string.Empty;
    public  string PublishingHouse { get; set; } = string.Empty;
    public  string BookCoverLink { get; set; } = string.Empty;
    public int NumberOfPages { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public bool AlreadyRead { get; set; }
}
