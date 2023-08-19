using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPostsByUserId(int userId);
        Task<List<Post>> GetPostsLikedByUser(int userId);
    }
}