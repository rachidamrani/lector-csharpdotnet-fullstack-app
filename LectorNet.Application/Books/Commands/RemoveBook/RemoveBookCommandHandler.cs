using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Books.Commands.RemoveBook;

public class RemoveBookCommandHandler(
    IBooksRepository booksRepository, 
    IUnitOfWork unitOfWork,
    ILogger<RemoveBookCommandHandler> logger) : IRequestHandler<RemoveBookCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(RemoveBookCommand command, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Removing book with ID {ID}", command.BookId);
            
            var book = await booksRepository.GetByIdAsync(command.BookId);

            if (book is null) return BookErrors.BookNotFound;

            if (book.UserId != Guid.Parse(command.UserId)) return Errors.Unauthorized;

            await booksRepository.DeleteAsync(book);

            await unitOfWork.CommitChangesAsync();
            
            logger.LogInformation("Book with ID {ID} removed succesfully !", command.BookId);
            
            return Unit.Value;
        }
        catch (Exception e)
        {
            logger.LogError("Error removing book with ID {ID}: {ErrorMessage}", command.BookId, e.Message);
            return Errors.UnexpectedError;
        }
    }
}