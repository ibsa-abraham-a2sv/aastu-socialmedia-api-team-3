using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPostsByUserId(Guid userId);
        Task<List<Post>> GetPostsLikedByUser(Guid userId);
    }
}