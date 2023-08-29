using AutoMapper;
using ErrorOr;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.Common.Interface.Services;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Services.Authentication;
using Galacticos.Domain.Entities;
using Galacticos.Domain.Errors;
using MediatR;

namespace Galacticos.Application.Features.Auth.Handlers.CommandHandlers
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, ErrorOr<string>>
    {
        private readonly IEmailSender _emailSender;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        public ForgotPasswordRequestHandler(IEmailSender emailSender, IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
        {
            _emailSender = emailSender;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<ErrorOr<string>> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByEmail(request.Email);

            if (user is null)
            {
                return Errors.User.UserNotFound;
            }

            var resetToken = _jwtTokenGenerator.GenerateToken(user);

            await _emailSender.SendEmail(
                new Email()
                {
                    To = user.Email,
                    Subject = "Reset Password",
                    Body = $"Please click the link to reset your password: https://localhost:5001/api/auth/reset-password?token={resetToken}"
                }
            )
        }
    }
}
