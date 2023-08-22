using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Features.Posts.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
             _mediator = mediator;

        }
        
        [HttpGet]
        public async Task<ActionResult<List<GetPostDto>>> Get()
        {
            var posts = await _mediator.Send(new GetPostsRequest());
            return Ok(posts);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDetailDto>> Get(Guid id)
        {
            var post = await _mediator.Send(new GetPostDetailRequest { Id = id });
            return post;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<GetPostDto>>> GetPostsLikedByUser(Guid userId)
        {
            var posts = await _mediator.Send(new GetPostsLikedByUserRequest { UserId = userId });
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] PostDto postDto)
        {
            var c = new CreatePostCommand { postDto = postDto };
            var post = await _mediator.Send(c);

            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] PostDto postDto)
        {
            var c = new UpdatePostCommand { postDto = postDto };
            var post = await _mediator.Send(c);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var c = new DeletePostCommand { Id = id };
            var post = await _mediator.Send(c);

            return NoContent();
        }
    }
}
