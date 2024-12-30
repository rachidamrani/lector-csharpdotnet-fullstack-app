using ErrorOr;

namespace LectorNet.Application.Authentication.Common;

public static class AuthenticationErrors
{
    public static readonly Error InvalidCredentials = Error.Validation(
        code: "Authentication.InvalidCredentials",
        description: "Adresse e-mail ou mot de passe incorrect.");

    public static readonly Error UserNotFound = Error.NotFound(
        code: "Authentication.UserNotFound",
        description: "L'utilisateur est introuvable");

    public static readonly Error UserAlreadyExists = Error.Conflict(
        code: "Authentication.UserAlreadyExists",
        description: "L’utilisateur existe déjà"
        );
}