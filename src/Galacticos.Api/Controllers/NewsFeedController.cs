using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Galacticos.Application.Features.NewsFeed.Request.Queries;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NewsFeedController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id, pageNumber, pageSize}")]
        public async Task<ActionResult<List<object>>> GetNewsFeedPosts(int id, int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetNewsFeedPostsRequest { Id = id, PageNumber = pageNumber, PageSize = pageSize });
            return Ok(result);
        }
    }
}