using LectorNet.Api.ValidationAttributes;
using LectorNet.Application.Books.Commands.CreateBook;
using LectorNet.Application.Books.Commands.RemoveBook;
using LectorNet.Application.Books.Commands.UpdateBook;
using LectorNet.Application.Books.Queries.GetBook;
using LectorNet.Application.Books.Queries.GetBooks;
using LectorNet.Contracts.Books;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LectorNet.Api.Controllers;

[Route("api/books")]
[ApiController]
public class BookController(ISender sender) : ApiController
{
    [HttpGet("{bookId:guid}")]
    public async Task<IActionResult> GetBookById(Guid bookId)
    {
        var query = new GetBookByIdQuery(bookId);
        
        var getBookResult = await sender.Send(query);

        return getBookResult.Match(
            book => Ok(book.Adapt<BookResponse>()), 
            Problem);
    }

    [HttpGet]
    [RequireConnectedUser]
    public async Task<IActionResult> GetBooks()
    {
        var connectedUserId = GetConnectedUser();
        
        var query = new GetBooksQuery(connectedUserId);
        
        var getBooksResult = await sender.Send(query);

        return getBooksResult.Match(
            books => Ok(books.Adapt<List<BookResponse>>()),
            Problem);
    }
    
    [HttpPost("new")]
    [RequireConnectedUser]
    public async Task<IActionResult> AddBook(CreateBookRequest request)
    {
        var connectedUserId = GetConnectedUser();
        
        var command = new CreateBookCommand(
            request.Title,
            request.Author,
            request.Isbn,
            request.Genre,
            request.PublicationYear,
            request.PublishingHouse,
            request.NumberOfPages,
            request.BookCoverLink,
            request.AlreadyRead,
            connectedUserId
        );

        var createBookResult = await sender.Send(command);

        return createBookResult.Match(
            book => Ok(book.Adapt<BookResponse>()), 
            Problem);
    }
    
    [HttpDelete("{bookId:guid}")]
    [RequireConnectedUser]
    public async Task<IActionResult> RemoveBook(Guid bookId)
    {
        var connectedUserId = GetConnectedUser();
        
        var command = new RemoveBookCommand(bookId, connectedUserId);
        
        var removeBookResult = await sender.Send(command);

        return removeBookResult.Match(
            value => Ok("Livre supprimé avec succés !"),
            Problem);
    }

    [HttpPut("{bookId:guid}")]
    [RequireConnectedUser]
    public async Task<IActionResult> UpdateBook(Guid bookId, UpdateBookRequest request)
    {
        var connectedUserId = GetConnectedUser();
        
        var command = new UpdateBookCommand(
            bookId,
            request.Title,
            request.Author,
            request.Isbn,
            request.Genre,
            request.PublicationYear,
            request.PublishingHouse,
            request.NumberOfPages,
            request.BookCoverLink,
            request.AlreadyRead,
            connectedUserId);
        
        var updateBookResult = await sender.Send(command);

        return updateBookResult.Match(book => Ok(book.Adapt<BookResponse>()), Problem);
    }
}
