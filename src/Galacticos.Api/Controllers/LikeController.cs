using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Galacticos.Application.DTOs.Likes;
using Galacticos.Application.Features.Likes.Request.Queries;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class LikeController : ApiController
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> LikePost(CreateLikeDto createLikeDto)
        {
            var result = await _mediator.Send(new LikePostRequest { createLikeDto = createLikeDto });
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (result == Guid.Empty)
                return NotFound(new { Message = "Post or user not found." });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Unit>> UnlikePost(LikeDto likeDto)
        {
            var result = await _mediator.Send(new DislikePostRequest { likeDto = likeDto });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (result.Equals(Unit.Value))
                return Unit.Value;

            return NotFound(new { Message = "Like not found." });
        }
    }
}