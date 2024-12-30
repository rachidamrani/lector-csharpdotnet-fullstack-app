using ErrorOr;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Commands.CreateBook;

public record CreatBookCommand(
    string Title,
    string Author,
    string Isbn,
    string Genre,
    string PublicationYear,
    string PublishingHouse,
    int NumberOfPages,
    string BookCoverLink,
    string UserId,
    bool AlreadyRead
    ) : IRequest<ErrorOr<Book>>;