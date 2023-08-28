using ErrorOr;
using Galacticos.Application.Services.Authentication;
using MediatR;
using Galacticos.Domain.Entities;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Features.Auth.Requests.Queries;
using Galacticos.Domain.Errors;

namespace Galacticos.Application.Handlers.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (query.UserName is null && query.Email is null)
            return Errors.Auth.UsernameEmailrequired;

        var identifier = (query.UserName ?? query.Email) ?? throw new Exception("Username or Email is required");

        if (_userRepository.GetUserByIdentifier(identifier) is not User user)
            return Errors.Auth.WrongCreadital;

        if (user.Password != query.Password)
            return Errors.Auth.WrongCreadital;

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}