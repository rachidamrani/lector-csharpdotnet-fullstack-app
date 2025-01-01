using ErrorOr;
using MediatR;

namespace LectorNet.Application.Books.Commands.RemoveBook;

public record RemoveBookCommand(Guid BookId, string UserId) : IRequest<ErrorOr<Unit>>;