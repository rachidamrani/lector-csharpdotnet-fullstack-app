using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using MediatR;

namespace LectorNet.Application.Books.Commands.RemoveBook;

public class RemoveBookCommandHandler(IBooksRepository booksRepository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveBookCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(RemoveBookCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var book = await booksRepository.GetByIdAsync(command.BookId);

            if (book is null) return BookErrors.BookNotFound;

            await booksRepository.DeleteAsync(book);

            await unitOfWork.CommitChangesAsync();

            return Unit.Value;
        }
        catch (Exception e)
        {
            return Errors.UnexpectedError;
        }
    }
}