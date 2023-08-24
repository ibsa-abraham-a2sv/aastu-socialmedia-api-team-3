// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using Xunit;
// using Moq;
// using AutoMapper;
// using Galacticos.Application.DTOs.Likes;
// using Galacticos.Application.Features.Likes.Request.Queries;
// using Galacticos.Application.Features.Likes.Handler.Queries;
// using Galacticos.Application.Persistence.Contracts;
// using Galacticos.Application.UnitTests.Mocks;

// namespace Galacticos.Application.UnitTests.Likes.Queries
// {
//     public class CreateLikesRequestHandlerTest
//     {
//         private readonly Mock<ILikeRepository> _likeRepository;
//         private readonly Mock<IUserRepository> _userRepository;
//         private readonly Mock<IPostRepository> _postRepository;
//         private readonly IMapper _mapper;

//         public CreateLikesRequestHandlerTest()
//         {
//             _likeRepository = MockRepositories.LikeRepository();
//             _userRepository = MockRepositories.UserRepository();
//             _postRepository = MockRepositories.PostRepository();

//             var mapperConfig = new MapperConfiguration(mc =>
//             {
//                 mc.AddProfile(new Profiles.LikeMappingProfile());
//             });

//             _mapper = mapperConfig.CreateMapper();
//         }

//         [Fact]
//         public async Task CreateLikesRequestHandler_Success()
//         {
//             var handler = new LikePostRequestHandler(_likeRepository.Object, _mapper);

//             var postId = new Guid("00000000-0000-0000-0000-000000000001");
//             var userId = new Guid("00000000-0000-0000-0000-000000000002");
            
//             var createLikeDto = new CreateLikeDto
//             {
//                 PostId = postId,
//                 UserId = userId
//             };

//             var request = new LikePostRequest { createLikeDto = createLikeDto };

//             // Act
//             var result = await handler.Handle(request, CancellationToken.None);

//             // Assert
//             Assert.IsType<Guid>(result);
//         }
//     }
// }