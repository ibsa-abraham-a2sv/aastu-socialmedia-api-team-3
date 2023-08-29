using Galacticos.Application.Persistence.Contracts;
using Microsoft.AspNetCore.Mvc;
using Galacticos.Application.DTOs.Relations;
using MediatR;
using Galacticos.Application.Features.Relation.Request.Query;
using Galacticos.Application.Features.Relation.Request.Command;
using Galacticos.Application.Features.Notifications.Commands;
using Galacticos.Application.DTOs.Notifications;
using Galacticos.Application.Features.Profile.Request.Queries;
using System.Security.Claims;
using Galacticos.Domain.Errors;
using Galacticos.Api.Services.NotificationService;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class RelationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationService _notificationService;
        public RelationController(IMediator mediator, IHttpContextAccessor httpContextAccessor, INotificationService notificationService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _notificationService = notificationService;
        }

        [HttpPost("Follow/{UserId}")]
        public async Task<ActionResult<Guid>> Follow(Guid UserId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");
            var currentUserId = Guid.Parse(userIdClaim);

            if (userIdClaim != null)
            {
                var relation = new RelationDTO
                {
                    FollowerId = Guid.Parse(userIdClaim),
                    FollowedUserId = UserId
                };

                var result = await _mediator.Send(new FollowCommand { RelationDTO = relation });

                if (result != Guid.Empty)
                {
                    // Send Notification
                    await _notificationService.UserIsFollowed(currentUserId, UserId);
                    return Ok(result);
                }

                return Guid.Empty;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("UnFollow/{UserId}")]
        public async Task<ActionResult<Guid>> UnFollow(Guid UserId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");
            var currentUserId = Guid.Parse(userIdClaim);

            if (userIdClaim != null)
            {
                var relation = new RelationDTO
                {
                    FollowerId = Guid.Parse(userIdClaim),
                    FollowedUserId = UserId
                };

                var result = await _mediator.Send(new UnFollowCommand { RelationDTO = relation });

                if (result != Guid.Empty)
                {
                    // Send Notification
                    await _notificationService.UserIsFollowed(currentUserId, UserId);
                    return Ok(result);
                }

                return Guid.Empty;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("{followedId}")]
        public async Task<ActionResult<RelationDTO>> Get(Guid followedId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim != null)
            {
                var relation = new RelationDTO
                {
                    FollowerId = Guid.Parse(userIdClaim),
                    FollowedUserId = followedId
                };
                var result = await _mediator.Send(new GetRelationRequest { RelationDTO = relation });
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("Allfollowers")]
        public async Task<ActionResult<List<Guid>>> GetFollowersIds()
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim != null)
            {
                var id = Guid.Parse(userIdClaim);
                var result = await _mediator.Send(new GetFollowersIdRequest { id = id });
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("Allfollowed")]
        public async Task<ActionResult<List<Guid>>> GetFollowedIds()
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim != null)
            {
                var id = Guid.Parse(userIdClaim);
                var result = await _mediator.Send(new GetFollowedIdsRequest { id = id });
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}