using ErrorOr;

namespace LectorNet.Application.Invitations.Common;

public static class InvitationErrors
{
    public static readonly Error InvitationAlreadySent = Error.Conflict(
        code: "Invitation.AlreadySent",
        description: "Vous avez déja invité cette personne");

    public static readonly Error SelfInvitationNotAllowed = Error.Unauthorized(
        code: "Invitation.Unauthorized",
        description: "Vous ne pouvez pas vous inviter vous-même");
}
