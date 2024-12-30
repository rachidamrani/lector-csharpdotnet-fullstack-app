using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Queries.GetBook;

public class GetBookByIdQueryHandler(IBooksRepository bookRepository) : IRequestHandler<GetBookByIdQuery, ErrorOr<Book>>
{
    public async Task<ErrorOr<Book>> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            Book? book = await bookRepository.GetByIdAsync(query.BookId);

            if (book is null) return BookErrors.BookNotFound;

            return book;
        }
        catch (Exception)
        {
            return Errors.UnexpectedError;
        }
    }
}