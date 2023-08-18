

using Galacticos.Application.Common.Interface.Authentication;

namespace Galacticos.Application.Services;

public class AuthenticationService : IAuthenticationService{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string username, string password){

        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, username, password);

        return new AuthenticationResult(
            userId,
            "John",
            "Doe",
            "johndoe",
            username,
            "bio",
            "profilePicture",
            token
        );
    }

    public AuthenticationResult Register(string FirstName, string LastName, string username, string password, string email){
        
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, username, password);
        
        return new AuthenticationResult(
            userId,
            FirstName,
            LastName,
            email,
            username,
            "bio",
            "profilePicture",
            token
        );
    }
}