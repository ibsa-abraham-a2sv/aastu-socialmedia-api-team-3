using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Galacticos.Api.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IUserRepository _userRepository;
        private readonly IUserConnectionRepository _userConnectionRepository;
        private readonly IPostRepository _postRepository;
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(IHubContext<NotificationHub> hubContext, IUserRepository userRepository, IUserConnectionRepository userConnectionRepository, IPostRepository postRepository, INotificationRepository notificationRepository)
        {
            _hubContext = hubContext;
            _userRepository = userRepository;
            _userConnectionRepository = userConnectionRepository;
            _postRepository = postRepository;
            _notificationRepository = notificationRepository;
        }

        public async Task SendNotificationToSingleUser(Guid userById, Guid userToId, string content)
        {
            var connectionId = await _userConnectionRepository.GetUserConnection(userToId);

            var notificaiton = new Notification
            {
                Content = content,
                UserById = userById,
                UserToId = userToId,
            };

            // If the user is online
            if (connectionId != null)
            {
                var notificationsList = await _notificationRepository.GetNotificationByUserId(userToId);
                var messages = new { notifications = notificationsList };
                await _hubContext.Clients.Client(connectionId.connectionId).SendAsync("ReceiveNotification", content);
            }
        }

        public async Task PostIsLiked(Guid postId, Guid userById)
        {
            var user = await _userRepository.GetUserByIdAsync(userById);
            var post = await _postRepository.GetById(postId);
            var content = $"{user.UserName} Liked Your Post";

            await SendNotificationToSingleUser(userById, post.UserId, content);

        }

        public async Task PostIsCommentedOn(Guid postId, Guid userById)
        {
            var user = await _userRepository.GetUserByIdAsync(userById);
            var post = await _postRepository.GetById(postId);
            var content = $"{user.UserName} Commented On Your Post";

            await SendNotificationToSingleUser(userById, post.UserId, content);
        }

        public async Task UserIsFollowed(Guid userById, Guid userToId)
        {
            var user = await _userRepository.GetUserByIdAsync(userById);
            var content = $"{user.UserName} Star To Follow You";

            await SendNotificationToSingleUser(userById, userToId, content);
        }

        public async Task UserIsUnFollowed(Guid userById, Guid userToId)
        {
            var user = await _userRepository.GetUserByIdAsync(userById);
            var content = $"{user.UserName} Just Unfollowed You";

            await SendNotificationToSingleUser(userById, userToId, content);
        }

    }
}