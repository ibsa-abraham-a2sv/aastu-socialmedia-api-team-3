namespace Galacticos.Application.Contract.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string? Bio,
    string? ProfilePicture,
    string Token
);