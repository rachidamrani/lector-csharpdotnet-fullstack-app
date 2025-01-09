using LectorNet.Api.ValidationAttributes;
using LectorNet.Application.Invitations.Commands;
using LectorNet.Contracts.Invitations;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LectorNet.Api.Controllers;

[Route("api/invitations")]
[ApiController]
public class InvitationController(ISender sender) : ApiController
{
    [HttpPost]
    [RequireConnectedUser]
    public async Task<IActionResult> CreateInvitation(string receiverEmail)
    {
        var connectedUserId = GetConnectedUser();   
        
        var command = new CreateInvitationCommand(receiverEmail, Guid.Parse(connectedUserId));
        
        var createInvitationResult = await sender.Send(command);

        return createInvitationResult.Match(
            invitation => Ok(invitation.Adapt<InvitationResponse>()), 
            Problem);
    } 
}