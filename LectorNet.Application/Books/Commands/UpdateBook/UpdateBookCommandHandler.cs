using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Books;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(
    IBooksRepository booksRepository, 
    IUnitOfWork unitOfWork,
    ILogger<UpdateBookCommandHandler> logger) : IRequestHandler<UpdateBookCommand, ErrorOr<Book>>
{
    public async Task<ErrorOr<Book>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Updating book with ID {ID}", command.BookId);

            var book = await booksRepository.GetByIdAsync(command.BookId);

            if (book is null) return BookErrors.BookNotFound;
            
            if(book.UserId != Guid.Parse(command.UserId)) return Errors.Unauthorized;
            
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
            
            logger.LogInformation("Book with ID {ID} has been updated", command.BookId);

            return book;
        }
        catch (Exception e)
        {
            logger.LogError("Error updating book with ID {ID}: {ErrorMessage}", command.BookId, e.Message);
            
            return Errors.UnexpectedError;
        }
    }
}