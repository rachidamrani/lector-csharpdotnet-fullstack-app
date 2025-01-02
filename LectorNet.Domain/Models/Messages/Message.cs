using LectorNet.Domain.Models.Common;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Domain.Models.Messages;

public class Message : BaseEntity
{
    public Guid SenderId { get; init; }
    public User? Sender { get; init; }
    public Guid ReceiverId { get; init; }
    public User? Receiver { get; init; }
    
    public string Text { get; init; } = string.Empty;
}