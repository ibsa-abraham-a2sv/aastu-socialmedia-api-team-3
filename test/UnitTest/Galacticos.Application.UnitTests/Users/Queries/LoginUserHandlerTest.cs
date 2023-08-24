// using Xunit;
// using Moq;
// using AutoMapper;
// using Galacticos.Application.Persistence.Contracts;
// using Galacticos.Application.UnitTests.Mocks;
// using Galacticos.Application.Handlers.Queries.Login;
// using Galacticos.Application.Common.Interface.Authentication;
// using Galacticos.Application.Features.Auth.Requests.Queries;
// using Galacticos.Application.Services.Authentication;

// namespace Galacticos.Application.UnitTests.Users.Queries
// {
//     public class LoginUserHandlerTest
//     {
//         private readonly Mock<IUserRepository> _userRepository;
//         private readonly Mock<IJwtTokenGenerator> _jwtTokenGenerator;
//         private readonly IMapper _mapper;

//         public LoginUserHandlerTest()
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
//         public async Task LoginUserHandler_Success()
//         {
//             // Arrange
//             var handler = new LoginQueryHandler(_userRepository.Object, _jwtTokenGenerator.Object);
//             var query = new LoginQuery
//             {
//                 UserName = "jhondoe",
//                 Email = "jhondoe",
//                 Password = "123456",
//             };

//             // Act
//             var result = await handler.Handle(query, CancellationToken.None);

//             // Assert
//             Assert.NotNull(result);
//             Assert.IsType<AuthenticationResult>(result);
               
//         }
//     }
// }