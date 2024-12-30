using ErrorOr;
using LectorNet.Application.Authentication.Common;
using MediatR;

namespace LectorNet.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;