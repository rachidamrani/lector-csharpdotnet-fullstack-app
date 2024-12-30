using ErrorOr;
using LectorNet.Application.Authentication.Common;
using MediatR;

namespace LectorNet.Application.Authentication.Queries;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
