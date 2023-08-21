using Galacticos.Application.Persistence.Contracts;
using Microsoft.AspNetCore.Mvc;
using Galacticos.Application.DTOs.Relations;
using MediatR;
using Galacticos.Application.Features.Relation.Request.Query;
using Galacticos.Application.Features.Relation.Request.Command;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class RelationController : Controller
    {
        private readonly IMediator _mediator;
        public RelationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Follow(RelationDTO relation)
        {
            var result = await _mediator.Send(new FollowCommand { RelationDTO = relation });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> UnFollow(RelationDTO relation)
        {
            var result = await _mediator.Send(new UnFollowCommand { RelationDTO = relation });
            return Ok(result);
        }

    }
}