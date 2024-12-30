using ErrorOr;

namespace LectorNet.Application.Common;

public static class Errors
{
    public static readonly Error UnexpectedError = Error.Unexpected(
        description: "Une erreur s'est produite");

    public static readonly Error Unauthorized = Error.Unauthorized(
        description: "Vous n’êtes pas autorisé à effectuer cette opération");
}
