using ErrorOr;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Books;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(
    IBooksRepository bookRepository, 
    IUnitOfWork unitOfWork,
    ILogger<CreateBookCommandHandler> logger)
    : IRequestHandler<CreateBookCommand, ErrorOr<Book>>
{
    public async Task<ErrorOr<Book>> Handle(
        CreateBookCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            logger.LogInformation("Creating book with ISBN {Isbn}", command.Isbn);
            
            var bookExists = await bookRepository.ExistsAsync(command.Isbn);

            if (bookExists) return BookErrors.BookAlreadyExists;

            var book = new Book
            {
                Title = command.Title,
                Author = command.Author,
                Isbn = command.Isbn,
                Genre = BookGenre.FromName(command.Genre),
                PublicationYear = command.PublicationYear,
                PublishingHouse = command.PublishingHouse,
                NumberOfPages = command.NumberOfPages,
                BookCoverLink = command.BookCoverLink,
                AlreadyRead = command.AlreadyRead,
                UserId = Guid.Parse(command.userId),
            };

            await bookRepository.AddAsync(book);
            await unitOfWork.CommitChangesAsync();
            
            logger.LogInformation("Created book with ISBN {Isbn}", command.Isbn);

            return book;
        }
        catch (Exception e)
        {
            logger.LogError("Error creating book with {Isbn}: {ErrorMessage}", command.Isbn, e.Message);
            return Errors.UnexpectedError;
        }
    }
}
