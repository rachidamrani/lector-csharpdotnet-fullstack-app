using LectorNet.Domain.Models.Books;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.UsersBooksReactions;

public class UserBookReaction
{
    public Guid UserId { get; init; }
    public User? User { get; init; }
    public Guid BookId { get; init; }
    public Book? Book { get; init; }
    public ReactionType Reaction { get; init; } = default!;
    public DateTime CreatedAt { get; init; }
}