

using Galacticos.Application.DTOs.Authentication;

namespace Galacticos.Application.Services;

public interface IAuthenticationService{
    AuthenticationResult Login(string username, string password);
    AuthenticationResult Register(string FirstName, string LastName, string username, string password, string email);
}