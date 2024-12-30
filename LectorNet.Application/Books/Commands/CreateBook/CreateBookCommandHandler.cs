using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IBooksRepository bookrepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreatBookCommand, ErrorOr<Book>>
{
    public async Task<ErrorOr<Book>> Handle(
        CreatBookCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            bool bookExists = await bookrepository.ExistsAsync(command.Isbn);

            if (bookExists) return BookErrors.BookAlreadyExists;

            Book book = new Book
            {
                Title = command.Title,
                Author = command.Author,
                Isbn = command.Isbn,
                Genre = BookGenre.FromName(command.Genre),
                PublicationYear = command.PublicationYear,
                PublishingHouse = command.PublishingHouse,
                NumberOfPages = command.NumberOfPages,
                BookCoverLink = command.BookCoverLink,
                UserId = Guid.Parse(command.UserId),
                AlreadyRead = command.AlreadyRead
            };

            await bookrepository.AddAsync(book);
            await unitOfWork.CommitChangesAsync();

            return book;
        }
        catch (Exception)
        {
            return Errors.UnexpectedError;
        }
    }
}
