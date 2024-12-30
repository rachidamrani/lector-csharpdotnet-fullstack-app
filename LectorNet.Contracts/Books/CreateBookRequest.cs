namespace LectorNet.Contracts.Books;

public record CreateBookRequest(
    string Title,
    string Author,
    string Isbn,
    string Genre,
    string PublicationYear,
    string PublishingHouse,
    int NumberOfPages,
    string BookCoverLink,
    string UserId,
    bool AlreadyRead = false);