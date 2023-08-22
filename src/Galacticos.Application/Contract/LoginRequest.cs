namespace Galacticos.Application.Contract.Authentication;

public record LoginRequest(
    string? UserName,
    string? Email,
    string Password
);