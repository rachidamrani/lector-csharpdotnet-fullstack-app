using ErrorOr;

namespace LectorNet.Application.Users.Common;

public static class UserErrors
{
    public static readonly Error UserNotFound = Error.NotFound(
        code: "Authentication.UserNotFound",
        description: "L'utilisateur est introuvable");

    public static readonly Error UserAlreadyExists = Error.Conflict(
        code: "Authentication.UserAlreadyExists",
        description: "L’utilisateur existe déjà"
    );
}