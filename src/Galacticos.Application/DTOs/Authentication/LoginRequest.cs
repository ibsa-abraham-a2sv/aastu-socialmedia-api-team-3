

namespace Galacticos.Application.DTOs.Authentication;

public record LoginRequest(
    string UserName,
    string Password
);