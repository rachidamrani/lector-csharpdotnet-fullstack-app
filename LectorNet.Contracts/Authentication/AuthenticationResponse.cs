using LectorNet.Domain.Models.Users;

namespace LectorNet.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Role
);
