// using AutoMapper;
// using Galacticos.Application.Persistence.Contracts;
// using Moq;
// using Galacticos.Application.Profiles;
// using Xunit;
// using Galacticos.Application.Features.Posts.Request.Queries;
// using Galacticos.Application.UnitTests.Mocks;
// using Galacticos.Application.Features.Posts.Handlers.Commands;
// using ErrorOr;
// using Galacticos.Application.DTOs.Posts;
// using Galacticos.Application.Features.Posts.Handlers.Queries;

// namespace Galacticos.Application.UnitTests.Posts.Queries
// {
//     public class PostRequestHandlerTest
//     {
//         private readonly Mock<IPostRepository> _postRepository;
//         private readonly Mock<IUserRepository> _userRepository;
//         // private readonly 
//         private readonly IMapper _mapper;
//         public PostRequestHandlerTest()
//         {
//             _postRepository = MockRepositories.PostRepository();
//             _userRepository = MockRepositories.UserRepository();

//             var mockMapper = new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile(new PostMappingProfile());
//             });

//             _mapper = mockMapper.CreateMapper();

//         }


//         [Fact]
//         public async Task valid_post_added()
//         {
//             var userId = new Guid("00000000-0000-0000-0000-000000000000");
//             var caption = "Test add function";
//             var image = "testAdd.png";
//             var handler = new CreatePostCommandHandler(_postRepository.Object, _mapper);

//             var result = await handler.Handle(new CreatePostCommand(){UserId = userId,Caption = caption,Image = image}, CancellationToken.None);
//             var posts = await _postRepository.Object.GetAll();
            
//             Assert.IsType<ErrorOr<PostResponesDTO>>(result);
//             Assert.Equal(3,posts.Count);
//         }

//         [Fact]
//         public async Task GetPostRequestHandler()
//         {
//             var userId = new Guid("00000000-0000-0000-0000-000000000000");
//             var handler = new GetPostQueryHandler(_postRepository.Object, _mapper);

//             var result = await handler.Handle(new GetPostQuery(userId), CancellationToken.None);
//             var posts = await _postRepository.Object.GetAll();
            
//             Assert.IsType<ErrorOr<PostResponesDTO>>(result);
//             Assert.NotNull(result.Value);
//             Assert.Equal(new Guid("00000000-0000-0000-0000-000000000000"),result.Value.Id);
//         }
//     }
// }