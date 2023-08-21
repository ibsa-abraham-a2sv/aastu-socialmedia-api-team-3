using ErrorOr;
using Galacticos.Application.Services.Authentication;
using MediatR;

namespace Galacticos.Application.Features.Auth.Requests.Commands;

public record RegisterCommand
(
    string FirstName = "",
    string LastName = "",
    string UserName = "",
    string Email = "",
    string? Bio = "",
    string? Picture = "",
    string Password = ""
) : IRequest<ErrorOr<AuthenticationResult>>;