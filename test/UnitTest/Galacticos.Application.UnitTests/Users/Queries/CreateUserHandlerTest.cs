// using Xunit;
// using Moq;
// using AutoMapper;
// using Galacticos.Application.Persistence.Contracts;
// using Galacticos.Application.UnitTests.Mocks;
// using Galacticos.Application.Handlers.Commands.Register;
// using Galacticos.Application.Common.Interface.Authentication;
// using Galacticos.Application.Features.Auth.Requests.Commands;
// using Galacticos.Application.Services.Authentication;

// namespace Galacticos.Application.UnitTests.Users.Queries
// {
//     public class CreateUserHandlerTest
//     {
//         private readonly Mock<IUserRepository> _userRepository;
//         private readonly Mock<IJwtTokenGenerator> _jwtTokenGenerator;
//         private readonly IMapper _mapper;
        

//         public CreateUserHandlerTest()
//         {
//             _userRepository = MockRepositories.UserRepository();
//             _jwtTokenGenerator = MockRepositories.GetJwtTokenGenerator();

//             var mapperConfig = new MapperConfiguration(mc =>
//             {
//                 mc.AddProfile(new Profiles.MappingProfile());
//             });

//             _mapper = mapperConfig.CreateMapper();
//         }


//         [Fact]
//         public async Task GetUserByIdHandler_Success()
//         {
//             // Arrange
//             var handler = new RegisterCommandHandler(_jwtTokenGenerator.Object, _userRepository.Object, _mapper);
//             var command = new RegisterCommand
//             {
//                 FirstName = "John",
//                 LastName = "Doe",
//                 UserName = "jhondoe",
//                 Email = "jhondoe",
//                 Password = "123456",
//                 Bio = "I am a software developer",
//                 Picture = "picture.jpg",
//             };

//             // Act
//             var result = await handler.Handle(command, CancellationToken.None);

//             // Assert
//             Assert.NotNull(result);
//             Assert.IsType<AuthenticationResult>(result.Value);
               
//         }
//     }
// }