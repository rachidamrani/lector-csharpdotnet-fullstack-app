using ErrorOr;
using LectorNet.Domain.Models.Invitations;
using MediatR;

namespace LectorNet.Application.Invitations.Commands;

public record CreateInvitationCommand(string ReceiverId, Guid SenderId) : IRequest<ErrorOr<Invitation>>;