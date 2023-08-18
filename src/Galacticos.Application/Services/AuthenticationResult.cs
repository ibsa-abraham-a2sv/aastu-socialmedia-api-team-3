

namespace Galacticos.Application.Services;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string? Bio,
    string? ProfilePicture,
    string Token
);