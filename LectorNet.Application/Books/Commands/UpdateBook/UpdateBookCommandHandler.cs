using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Books;
using MediatR;

namespace LectorNet.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(IBooksRepository booksRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand, ErrorOr<Book>>
{
    public async Task<ErrorOr<Book>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var book = await booksRepository.GetByIdAsync(command.BookId);

            if (book is null) return BookErrors.BookNotFound;

            if (book.UserId != Guid.Parse(command.UserId))
            {
                return Errors.Unauthorized;
            }

            book.Title = command.Title;
            book.Author = command.Author;
            book.Isbn = command.Isbn;
            book.Genre = BookGenre.FromName(command.Genre);
            book.PublicationYear = command.PublicationYear;
            book.PublishingHouse = command.PublishingHouse;
            book.BookCoverLink = command.BookCoverLink;
            book.NumberOfPages = command.NumberOfPages;
            book.AlreadyRead = command.AlreadyRead;
        
            await booksRepository.UpdateAsync(book);

            await unitOfWork.CommitChangesAsync();

            return book;
        }
        catch (Exception e)
        {
            return Errors.UnexpectedError;
        }
    }
}