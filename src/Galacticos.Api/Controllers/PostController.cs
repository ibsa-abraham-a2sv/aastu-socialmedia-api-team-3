using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Features.Posts.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Galacticos.Api.Controllers
{

    [Route("api/[controller]")]
    public class PostController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PostController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreatePost(Guid userId, CreatePostRequestDTO request)
        {
            var command = _mapper.Map<CreatePostCommand>(request);
            command.UserId = userId;
            ErrorOr<PostResponesDTO> result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                post => Ok(post),
                errors => BadRequest(errors)
            );
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
        public async Task<IActionResult> DeletePost(Guid postId, Guid userId)
        {
            var command = new DeletePostCommand(postId, userId);
            ErrorOr<bool> result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                post => Ok(post),
                errors => BadRequest(errors)
            );
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterPostByTag(List<string> tags)
        {
            var query = new GetFilterdPostQuery(tags);
            List<PostResponesDTO> result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
