using ErrorOr;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using LectorNet.Application.Users.Common;
using LectorNet.Domain.Models.Invitations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Invitations.Commands;

public class CreateInvitationCommandHandler(
    IUsersRepository usersRepository,
    IInvitationsRepository invitationsRepository,
    IUnitOfWork unitOfWork,
    ILogger<CreateInvitationCommandHandler> logger
    ) : IRequestHandler<CreateInvitationCommand, ErrorOr<Invitation>>
{
    public async Task<ErrorOr<Invitation>> Handle(CreateInvitationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Creating invitation for user with ID : {Receiver}", command.ReceiverId);
            
            // Verify if the user receiver exists
            var receiver = await usersRepository.GetByEmailAsync(command.ReceiverId);

            // If user does not exist return error
            if (receiver is null) return UserErrors.UserNotFound;

            // If user exists create the invitation
            var invitation = new Invitation { ReceiverId = receiver.Id, SenderId = command.SenderId };

            await invitationsRepository.AddAsync(invitation);
            await unitOfWork.CommitChangesAsync();

            return invitation;
        }
        catch (Exception e)
        {
            logger.LogError("Error sending invitation to user with ID : {Receiver} {ErrorMessage}", command.ReceiverId, e.Message);
            
            return Errors.UnexpectedError;
        }
    }
}