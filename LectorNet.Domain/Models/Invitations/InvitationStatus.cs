using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.Invitation;

public class InvitationStatus(string name, int value) : SmartEnum<InvitationStatus>(name, value)
{
    public static readonly InvitationStatus Pending = new(nameof(Pending), 0);
    public static readonly InvitationStatus Accepted = new(nameof(Accepted), 1);
    public static readonly InvitationStatus Declined = new(nameof(Declined), 2);
}