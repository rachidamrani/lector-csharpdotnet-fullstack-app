using FluentAssertions;
using LectorNet.Application.Books;
using LectorNet.Application.Books.Commands.CreateBook;
using LectorNet.Application.Books.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Books;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace LectorNet.Unit.Tests.Books;

public class CreateBookHandlerTests
{
    
    private readonly CreateBookCommandHandler _sut;
    private readonly IBooksRepository _bookRepository = Substitute.For<IBooksRepository>();
    private readonly ILogger<CreateBookCommandHandler> _logger = Substitute.For<ILogger<CreateBookCommandHandler>>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public CreateBookHandlerTests()
    {
        _sut = new CreateBookCommandHandler(_bookRepository, _unitOfWork, _logger);
    }

    [Fact]
    public async Task Handle_ShouldCreateBook_WhenAllBooksInformationsAreValidAndBookDoesNotExist()
    {
        // Arrange
        var command = new CreateBookCommand(
            Title: "Deep C#: Dive Into Modern C#",
            Author: "John Doe",
            Isbn: "978-3-16-148410-0",
            Genre: "Informatique",
            PublicationYear: "2023",
            PublishingHouse: "Tech Publications",
            NumberOfPages: 500,
            BookCoverLink: "https://example.com/deep-csharp-cover.jpg",
            AlreadyRead: false,
            Guid.NewGuid().ToString());
        
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

        _bookRepository.ExistsAsync(command.Isbn).Returns(Task.FromResult(false));
        _bookRepository.AddAsync(book).Returns(Task.CompletedTask);

        // Act
        var result = (await _sut.Handle(command, CancellationToken.None)).Value;

        // Assert
        result.Should().BeEquivalentTo(book);
    }

    [Fact]
    public async Task Handle_ShouldNotCreateBook_WhenBookAlreadyExists()
    {
        // Arrange
        var command = new CreateBookCommand(
            Title: "Deep C#: Dive Into Modern C#",
            Author: "John Doe",
            Isbn: "978-3-16-148410-0",
            Genre: "Informatique",
            PublicationYear: "2023",
            PublishingHouse: "Tech Publications",
            NumberOfPages: 500,
            BookCoverLink: "https://example.com/deep-csharp-cover.jpg",
            AlreadyRead: false,
            Guid.NewGuid().ToString());
        
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

        _bookRepository.ExistsAsync(command.Isbn).Returns(true);
        _bookRepository.AddAsync(book).Returns(Task.CompletedTask);

        // Act
        var result = (await _sut.Handle(command, CancellationToken.None)).FirstError;

        // Assert
        result.Should().Be(BookErrors.BookAlreadyExists);
    }

    [Fact]
    public async Task Handle_ShouldReturnUnexpectedError_WhenCreatingBookFails()
    {
        // Arrange
        var command = new CreateBookCommand(
            Title: "Deep C#: Dive Into Modern C#",
            Author: "John Doe",
            Isbn: "978-3-16-148410-0",
            Genre: "Informatique",
            PublicationYear: "2023",
            PublishingHouse: "Tech Publications",
            NumberOfPages: 500,
            BookCoverLink: "https://example.com/deep-csharp-cover.jpg",
            AlreadyRead: false,
            Guid.NewGuid().ToString());
        
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

        _bookRepository.ExistsAsync(command.Isbn).Returns(Task.FromResult(false));
        
        _bookRepository.AddAsync(Arg.Any<Book>())
            .Returns(Task.FromException<Book>(new Exception()));
        
        // Act
        var result = (await _sut.Handle(command, CancellationToken.None)).FirstError;
        
        // Assert
        result.Should().Be(Errors.UnexpectedError);
    }
}