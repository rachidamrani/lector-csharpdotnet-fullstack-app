using ErrorOr;
using LectorNet.Application.Common;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Queries.GetBooks;

public class GetBooksQueryHandler(IBooksRepository booksRepository) : IRequestHandler<GetBooksQuery, ErrorOr<List<Book>>>
{
    public async Task<ErrorOr<List<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await booksRepository.GetAllAsync();

            return books;
        }
        catch (Exception e)
        {
            return Errors.UnexpectedError;
        }
    }
}