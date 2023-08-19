

namespace Galacticos.Application.DTOs.User;

public record UserDTO(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string? Bio,
    string? ProfilePicture
);