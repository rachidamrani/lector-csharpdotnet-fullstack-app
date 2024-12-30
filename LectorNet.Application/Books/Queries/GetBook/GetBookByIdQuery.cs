using ErrorOr;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Queries.GetBook;

public record GetBookByIdQuery(Guid BookId) : IRequest<ErrorOr<Book>>;