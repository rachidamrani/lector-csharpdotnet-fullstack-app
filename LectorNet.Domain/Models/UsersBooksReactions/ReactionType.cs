using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.UsersBooksReactions;

public class ReactionType(string name, int value) : SmartEnum<ReactionType>(name, value)
{
    public static readonly ReactionType Dislike = new(nameof(Dislike), 0);
    public static readonly ReactionType Like = new(nameof(Like), 1);
}