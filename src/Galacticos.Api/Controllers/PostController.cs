using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Features.Posts.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Galacticos.Api.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class PostController : ApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PostController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequestDTO request)
        {
        var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim != null)
            {
                var command = _mapper.Map<CreatePostCommand>(request);
                command.UserId = Guid.Parse(userIdClaim);
                ErrorOr<PostResponesDTO> result = await _mediator.Send(command);

                return result.Match<IActionResult>(
                    post => Ok(post),
                    errors => BadRequest(errors)
                );
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPost(Guid postId)
        {
            var query = new GetPostQuery(postId);
            ErrorOr<PostResponesDTO> result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                post => Ok(post),
                errors => BadRequest(errors)
            );
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPostsByUserId(Guid userId)
        {
            var query = new GetPostsByUserIdQuery(userId);
            ErrorOr<List<PostResponesDTO>> result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                posts => Ok(posts),
                errors => BadRequest(errors)
            );
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(Guid postId, UpdatePostRequestDTO updatePostRequestDTO)
        {
            UpdatePostCommand request = new UpdatePostCommand()
            {
                PostId = postId,
                UpdatePostRequestDTO = updatePostRequestDTO
            };
            ErrorOr<PostResponesDTO> result = await _mediator.Send(request);

            return result.Match<IActionResult>(
                post => Ok(post),
                errors => BadRequest(errors)
            );
        }

        [HttpGet("user/{userId}/liked")]
        public async Task<IActionResult> GetPostsLikedByUser(Guid userId)
        {
            var query = new GetPostsLikedByUserQuery(userId);
            ErrorOr<List<PostResponesDTO>> result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                posts => Ok(posts),
                errors => BadRequest(errors)
            );
        }

        [HttpDelete("{postId}/{userId}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(Guid postId, Guid userId)
        {
            var command = new DeletePostCommand(postId, userId);
            ErrorOr<bool> result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                post => Ok(post),
                errors => BadRequest(errors)
            );
        }
    }
}
