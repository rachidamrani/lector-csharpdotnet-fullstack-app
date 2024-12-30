using LectorNet.Domain.Models.Books;
using LectorNet.Domain.Models.Common;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.UsersReviews;

public class UserReview
{
    public Guid UserId { get; init; }
    public User? User { get; init; }
    public Guid BookId { get; init; }
    public Book? Book { get; init; }
    
    public int Rating { get; init; }

    public string Comment { get; init; } = string.Empty;
    
    public DateTime CreatedAt { get; init; }
}