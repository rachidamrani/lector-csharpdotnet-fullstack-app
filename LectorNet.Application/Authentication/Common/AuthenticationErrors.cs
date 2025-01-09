using ErrorOr;

namespace LectorNet.Application.Authentication.Common;

public static class AuthenticationErrors
{
    public static readonly Error InvalidCredentials = Error.Validation(
        code: "Authentication.InvalidCredentials",
        description: "Adresse e-mail ou mot de passe incorrect");
}