using ErrorOr;

namespace LectorNet.Application.Books.Common;

public static class BookErrors
{
    public static readonly Error BookAlreadyExists = Error.Conflict(
        code: "Book.AlreadyExists",
        description: "Ce livre existe déja");

    public static readonly Error BookNotFound = Error.NotFound(
        code: "Book.NotFound",
        description: "Ce livre est introuvable");
}
