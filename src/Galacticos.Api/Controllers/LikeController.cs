using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;
using Galacticos.Application.Features.Likes.Command.Queries;
using ErrorOr;
using Galacticos.Application.DTOs.Likes;
using Galacticos.Application.Features.Posts.Request.Queries;
using Galacticos.Application.Features.Notifications.Commands;
using Galacticos.Application.Features.Profile.Request.Queries;
using Galacticos.Application.DTOs.Notifications;
using Galacticos.Api.Services.NotificationService;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class LikeController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationService _notificationService;

        public LikeController(IMediator mediator, IHttpContextAccessor httpContextAccessor, INotificationService notificationService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _notificationService = notificationService;
        }

        [HttpPost("{PostId}")]
        public async Task<IActionResult> LikePost(Guid PostId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");
            var userId = Guid.Parse(userIdClaim);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var command = new LikePostRequest { PostId = PostId, UserId = userId };
            ErrorOr<LikeResponseDto> result = await _mediator.Send(command);

            await _notificationService.PostIsLiked(PostId, userId);
            return result.Match<IActionResult>(
                like => Ok(like),
                errors => Problem(errors)
            );

        }

        [HttpDelete("{PostId}")]
        public async Task<IActionResult> UnlikePost(Guid PostId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var command = new DislikePostRequest { PostId = PostId, UserId = Guid.Parse(userIdClaim) };
            ErrorOr<bool> result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                like => Ok(like),
                errors => Problem(errors)
            );
        }
    }
}