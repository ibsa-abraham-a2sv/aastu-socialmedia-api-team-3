

namespace Galacticos.Application.DTOs.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string? Bio,
    string? ProfilePicture,
    string Password
);