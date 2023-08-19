using Galacticos.Domain.Entities;


namespace Galacticos.Application.Persistence.Contracts
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        Task<Like> LikePost(int userId, int postId);
        Task<Like> GetLikeByPostIdAndUserId(int postId, int userId);
           
    }
}