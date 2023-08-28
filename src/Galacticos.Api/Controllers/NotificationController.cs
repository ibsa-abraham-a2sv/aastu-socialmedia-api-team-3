using Galacticos.Application.DTOs.Notifications;
using Galacticos.Application.Features.Notifications.Commands;
// using Galacticos.Application.Features.Notifications.Request.Request;
using Galacticos.Application.Features.Notifications.Requests;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Galacticos.Api.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator, INotificationRepository notificationRepository)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateNotificationDTO>> CreateNotification(CreateNotificationDTO notification)
        {
            var createdNotification = await _mediator.Send(new CreateNotificationCommand { NotificationDTO = notification });
            return createdNotification;
        }


        [HttpGet("{notificationId}")]
        public async Task<ActionResult<GetNotificationDTO>> GetNotificationById(Guid notificationId)
        {
            var notification = await _mediator.Send(new GetNotificationByIdRequest { NotificationId = notificationId });

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }


        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetNotificationsByUserId(Guid userId)
        {
            var request = new GetNotificationByUserIdRequest { UserToId = userId };
            var notifications = await _mediator.Send(request);

            return Ok(notifications);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllNotifications()
        {
            var request = new GetAllNotificationsRequest();
            var notifications = await _mediator.Send(request);

            return Ok(notifications);
        }

    }
}