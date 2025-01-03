using ErrorOr;
using LectorNet.Application.Common;
using LectorNet.Domain.Models.Books;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Books.Queries.GetBooks;

public class GetBooksQueryHandler(
    IBooksRepository booksRepository,
    ILogger<GetBooksQueryHandler> logger) : IRequestHandler<GetBooksQuery, ErrorOr<List<Book>>>
{
    public async Task<ErrorOr<List<Book>>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Getting all books");
            
            var books = await booksRepository.GetAllAsync(Guid.Parse(query.UserId));

            return books;
        }
        catch (Exception e)
        {
            logger.LogError("Error getting all books: {ErrorMessage}", e.Message);
            
            return Errors.UnexpectedError;
        }
    }
}