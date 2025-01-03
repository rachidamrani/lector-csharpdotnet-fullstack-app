using LectorNet.Domain.Models.Users;

namespace LectorNet.Contracts.Books;

public record BookResponse(
    Guid Id,
    string Title,
    string Author,
    string Isbn,
    string Genre,
    string PublicationYear,
    string PublishingHouse,
    string BookCoverLink,
    int NumberOfPages,
    UserInfoResponse UserInfos,
    bool AlreadyRead);
    
public record UserInfoResponse(string FirstName, string LastName);