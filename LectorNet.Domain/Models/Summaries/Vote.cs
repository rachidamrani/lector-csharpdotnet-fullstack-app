using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.Summaries;

public class Vote(string name, int value) : SmartEnum<Vote>(name, value)
{
    public static readonly Vote NoteVoted = new Vote("None", 0);
    public static readonly Vote Up = new Vote("Positive", 1);
    public static readonly Vote Down = new Vote("Negative", 2);
}