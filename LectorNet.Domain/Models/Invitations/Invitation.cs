using LectorNet.Domain.Models.Invitation;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.Invitations;

public class Invitation
{
    public Guid SenderId { get; init; }
    public User? Sender { get; init; }
    public Guid ReceiverId { get; init; }
    public User? Receiver { get; init; }
    public InvitationStatus Status { get; init; } = InvitationStatus.Pending;
    public DateTime CreatedAt { get; init; }
}