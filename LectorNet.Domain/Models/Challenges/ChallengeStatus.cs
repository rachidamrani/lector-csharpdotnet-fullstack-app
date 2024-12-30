using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.Challenges;

public class ChallengeStatus(string name, int value) : SmartEnum<ChallengeStatus>(name, value)
{
    public static readonly ChallengeStatus NotStarted = new (nameof(NotStarted), 0);
    public static readonly ChallengeStatus InProgress = new (nameof(InProgress), 1);
    public static readonly ChallengeStatus Completed = new (nameof(Completed), 2);
    public static readonly ChallengeStatus Abandoned = new (nameof(Abandoned), 3);
}