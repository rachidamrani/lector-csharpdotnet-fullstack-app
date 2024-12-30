using LectorNet.Domain.Models.Books;
using LectorNet.Domain.Models.Common;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.Challenges;

public class Challenge : BaseEntity
{
    public string Description { get; init; } = default!;
    
    public string Goal { get; init; } = default!;
    public Book? Book { get; init; }
    public Guid BookId { get; init; }
    public User? User { get; init; }
    public Guid UserId { get; init; }
    
    public int NumberOfPages { get; init; }
    public ChallengeStatus Status { get; init; } = default!;
    
    public DateOnly StartDate { get; init; }
    
    public DateOnly EstimatedEndDate { get; init; }
}