namespace Galacticos.Api.Services.NotificationService
{
    public interface INotificationService
    {
        Task SendNotificationToSingleUser(Guid userById, Guid userToId, string message);
        public Task PostIsLiked(Guid postId, Guid userById);
        public Task PostIsCommentedOn(Guid postId, Guid userById);
        public Task UserIsFollowed(Guid userById, Guid userToId);
        public Task UserIsUnFollowed(Guid userById, Guid userToId);
    }
}