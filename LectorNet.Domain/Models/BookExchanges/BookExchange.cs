using LectorNet.Domain.Models.Books;
using LectorNet.Domain.Models.Common;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.BookExchanges;

public class BookExchange : BaseEntity
{
    public Book? Book { get; init; }
    public Guid BookId { get; init; }
    public User? Owner { get; init; }
    public Guid OwnerId { get; init; }
    public User? Requester { get; init; }
    public Guid RequesterId { get; init; }
    public BookExchangeStatus Status { get; init; } = BookExchangeStatus.Pending;
}