using ErrorOr;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Commands.CreateBook;

public record CreateBookCommand(
    string Title,
    string Author,
    string Isbn,
    string Genre,
    string PublicationYear,
    string PublishingHouse,
    int NumberOfPages,
    string BookCoverLink,
    bool AlreadyRead,
    string userId) : IRequest<ErrorOr<Book>>;