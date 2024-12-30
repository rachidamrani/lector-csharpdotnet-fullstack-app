using LectorNet.Domain.Models.Books;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.Summaries;

public class Summary
{
    public string Content { get; init; } = null!;
    public User? Author { get; init; }
    public Guid AuthorId { get; init; }
    public Book? Book { get; init; }
    public Guid BookId { get; init; }
    public Vote Vote { get; init; } = Vote.NoteVoted;
    public DateTime CreatedAt { get; init; }
}