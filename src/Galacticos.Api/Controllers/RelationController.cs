using Microsoft.AspNetCore.Mvc;
using Galacticos.Application.DTOs.Relations;
using MediatR;
using Galacticos.Application.Features.Relation.Request.Query;
using Galacticos.Application.Features.Relation.Request.Command;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class RelationController : ApiController
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

        [HttpGet]
        public async Task<ActionResult<RelationDTO>> Get(RelationDTO relation)
        {
            var result = await _mediator.Send(new GetRelationRequest { RelationDTO = relation });
            return Ok(result);
        }

        [HttpGet("followed")]
        public async Task<ActionResult<List<Guid>>> GetFollowedIds(Guid id)
        {
            var result = await _mediator.Send(new GetFollowedIdsRequest { id = id });
            return Ok(result);
        }

    }
}