using LectorNet.Domain.Models.Books;

namespace LectorNet.Contracts.Books;

public record BookResponse(
    Guid Id,
    string Title,
    string Author,
    string Isbn,
    string Genre,
    string PublicationYear,
    string PublishingHouse,
    int NumberOfPages,
    bool AlreadyRead);