// // using Xunit;
// using Moq;
// using AutoMapper;
// using Galacticos.Application.Persistence.Contracts;
// using Galacticos.Application.UnitTests.Mocks;
// using Galacticos.Application.Profiles;
// using Galacticos.Application.Features.Profile.Request.Queries;
// using Galacticos.Application.Features.Profile.Handler.QueryHandler;
// using Galacticos.Application.DTOs.Profile;
// using ErrorOr;
// using Galacticos.Application.Features.Comments.Handler.Query;
// using Galacticos.Application.Features.Comments.Request.Queries;
// using Xunit;
// using Galacticos.Application.Features.Profile.Handler.CommandHandler;
// using Galacticos.Application.Features.Profile.Request.Commands;

// namespace Galacticos.Application.UnitTests.Profiles.Queries
// {
//     public class ProfileRequestHandlerTest
//     {
//         private readonly Mock<IUserRepository> _profileRepository;
//         private readonly IMapper _mapper;


//         public ProfileRequestHandlerTest()
//         {
//             _profileRepository = MockRepositories.ProfileRepository();

//             var mapperConfig = new MapperConfiguration(mc =>
//             {
//                 mc.AddProfile(new UserProfileMappingAutomapper());
//             });

//             _mapper = mapperConfig.CreateMapper();
//         }


//         [Fact]
//         public async Task GetProfileByIdHandler_Success()
//         {
//             var handler = new GetProfileRequestHandler(_mapper, _profileRepository.Object);

//             var command = new GetProfileRequest
//             {
//                 UserId = new Guid("22222222-2222-2222-2222-222222222222"),
//             };

//             var result = await handler.Handle(command, CancellationToken.None);
//             Assert.NotNull(result);
//             Assert.IsType<ErrorOr<ProfileResponseDTO>>(result);
//             Assert.NotNull(result.Value);
//             Assert.Equal(result.Value.Id, new Guid("22222222-2222-2222-2222-222222222222"));
//         }


//         [Fact]
//         public async Task GetAllProfilesHandler_Success()
//         {
//             var handler = new GetAllProfileRequestHandler(_profileRepository.Object, _mapper);

//             var command = new GetAllProfileRequest();

//             var result = await handler.Handle(command, CancellationToken.None);

//             Assert.NotNull(result);
//             Assert.IsType<List<ProfileResponseDTO>>(result);
//             Assert.Equal(result.Count, 1);
//         }


//         [Fact]
//         public async Task UpdateProfileHandler_Success()
//         {
//             var handler = new EditProfileRequestHandler(_profileRepository.Object, _mapper);

//             var command = new EditProfileRequest
//             {
//                 UserId = new Guid("22222222-2222-2222-2222-222222222222"),
//                 EditProfileRequestDTO = new EditProfileRequestDTO
//                 {
//                     FirstName = "UpdatedFirstName",
//                     LastName = "UpdatedLastName",
//                     Bio = "UpdatedBio",
//                     Picture = "UpdatedImage",
//                 }
//             };

//             var result = await handler.Handle(command, CancellationToken.None);

//             Assert.NotNull(result);
//             Assert.IsType<ErrorOr<ProfileResponseDTO>>(result);
//             Assert.NotNull(result.Value);
//             Assert.Equal(result.Value.FirstName, "UpdatedFirstName");
//             Assert.Equal(result.Value.LastName, "UpdatedLastName");
//             Assert.Equal(result.Value.Bio, "UpdatedBio");
//             Assert.Equal(result.Value.Picture, "UpdatedImage");
//         }
//     }
// }
