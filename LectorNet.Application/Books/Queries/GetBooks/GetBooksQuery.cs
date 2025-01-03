using ErrorOr;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Queries.GetBooks;

public record GetBooksQuery(string UserId) : IRequest<ErrorOr<List<Book>>>;