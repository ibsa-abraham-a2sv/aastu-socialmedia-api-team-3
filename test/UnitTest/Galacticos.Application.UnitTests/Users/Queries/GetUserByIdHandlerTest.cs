using Xunit;
using Moq;
using AutoMapper;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.UnitTests.Mocks;
using Galacticos.Application.DTOs.Users;
using Galacticos.Application.Features.Auth.Requests.Queries;
using Galacticos.Application.Handlers.Commands.Register;
using Galacticos.Application.Common.Interface.Authentication;

namespace Galacticos.Application.UnitTests.Users.Queries
{
    public class GetUserByIdHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IJwtTokenGenerator> _jwtTokenGenerator;
        private readonly IMapper _mapper;
        private readonly IMapper _mapper2;
        

        public GetUserByIdHandlerTest()
        {
            _userRepository = MockRepositories.UserRepository();
            _jwtTokenGenerator = MockRepositories.GetJwtTokenGenerator();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles.MappingProfile());
            });

            var mapperConfig2 = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles.UserProfileMappingAutomapper());
            });

            _mapper = mapperConfig.CreateMapper();
            _mapper2 = mapperConfig2.CreateMapper();
        }


        [Fact]
        public async Task GetUserByIdHandler_Success()
        {
            var handler = new RegisterCommandHandler(_jwtTokenGenerator.Object, _userRepository.Object, _mapper);

            var userId = new Guid("00000000-0000-0000-0000-000000000000");
            
            var request = new GetUserByIdQuery { Id = userId };

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsType<UserResponseDTO>(result);
        }
    }
}