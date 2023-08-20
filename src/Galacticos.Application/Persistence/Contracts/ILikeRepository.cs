using Galacticos.Domain.Entities;


namespace Galacticos.Application.Persistence.Contracts
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        Task<Like> LikePost(int postId, Guid userId);
        Task<Like> GetLikeByPostIdAndUserId(int postId, Guid userId);

        Task<Like> UnlikePost(int postId, Guid userId);
           
    }
}