using ErrorOr;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Services.Authentication;
using MediatR;
using Galacticos.Domain.Entities;
using Galacticos.Application.Features.Auth.Requests.Commands;
using AutoMapper;

namespace Galacticos.Application.Handlers.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByIdentifier(command.Email) is not null || _userRepository.GetUserByIdentifier(command.UserName) is not null)
            throw new Exception("User already exists");

        User user = _mapper.Map<User>(command);
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}