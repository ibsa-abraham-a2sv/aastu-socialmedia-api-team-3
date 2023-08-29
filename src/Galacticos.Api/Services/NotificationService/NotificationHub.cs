using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using System.Security.Claims;

namespace Galacticos.Api.Services.NotificationService
{
    public class NotificationHub : Hub
    {
        private readonly IUserConnectionRepository _userConnectionRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationHub(IUserConnectionRepository userConnectionRepository, INotificationRepository notificationRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userConnectionRepository = userConnectionRepository ?? throw new ArgumentNullException(nameof(userConnectionRepository));
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public override async Task OnConnectedAsync()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirstValue("uid");
            var connectionId = Context.ConnectionId;

            if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out var id))
            {
                var userConnection = new UserConnection
                {
                    userId = id,
                    connectionId = connectionId
                };

                await _userConnectionRepository.CreateAsync(userConnection);

                var notification = await _notificationRepository.GetNotificationByUserId(id);
                if (notification != null)
                {
                    await Clients.Client(connectionId).SendAsync("ReceiveNotification", notification);
                }
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirstValue("uid");
            if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out var id))
            {
                await _userConnectionRepository.CleanUpMapping(id);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
