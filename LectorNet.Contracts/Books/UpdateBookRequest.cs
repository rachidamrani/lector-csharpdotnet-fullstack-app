namespace LectorNet.Contracts.Books;

public record UpdateBookRequest(
    string Title,
    string Author,
    string Isbn,
    string Genre,
    string PublicationYear,
    string PublishingHouse,
    int NumberOfPages,
    string BookCoverLink,
    string UserId,
    bool AlreadyRead);