using ErrorOr;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Services.Authentication;
using MediatR;
using Galacticos.Domain.Entities;
using Galacticos.Application.Features.Auth.Requests.Commands;
using AutoMapper;
using Galacticos.Domain.Errors;
using Galacticos.Application.DTOs.Users;

namespace Galacticos.Application.Handlers.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHashService _passwordHashService;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHashService = passwordHashService;
    }

    public  Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // if(_userRepository.GetUserByIdentifier(command.Email) is not null || _userRepository.GetUserByIdentifier(command.UserName) is not null)
        // {
        //     return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateEmail);
        // }
        if(_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateEmail);
        }
        if(_userRepository.GetUserByUserName(command.UserName) is not null)
        {
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateUserName);
        }
        if(command.Password != command.ConfirmPassword)
        {
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.PasswordNotMatch);
        }

        string password = _passwordHashService.HashPassword(command.Password);
        // copy command and change password and save to vas userdata
        var userData = command with { Password = password };

        User user = _mapper.Map<User>(userData);
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        UserDto userDto = _mapper.Map<UserDto>(user);

       
        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(userDto, token));

    }
}