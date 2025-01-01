using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Domain.Models.Books;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Books.Queries.GetBook;

public class GetBookByIdQueryHandler(
    IBooksRepository bookRepository,
    ILogger<GetBookByIdQueryHandler> logger) : IRequestHandler<GetBookByIdQuery, ErrorOr<Book>>
{
    public async Task<ErrorOr<Book>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Getting book with ID {ID}", query.BookId);
            
            var book = await bookRepository.GetByIdAsync(query.BookId);

            if (book is null) return BookErrors.BookNotFound;

            return book;
        }
        catch (Exception e)
        {
            logger.LogError("Error getting book with ID {ID}: {ErrorMessage}", query.BookId, e.Message);
            
            return Errors.UnexpectedError;
        }
    }
}