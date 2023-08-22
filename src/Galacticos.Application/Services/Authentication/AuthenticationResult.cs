using Galacticos.Domain.Entities;

namespace Galacticos.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);