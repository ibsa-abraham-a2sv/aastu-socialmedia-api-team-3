using Galacticos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Galacticos.Application.Persistence.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<bool> Exists(Guid id);
        Task<List<Post>> GetPostsByUserId(int userId);
        Task<List<Post>> GetPostsLikedByUser(int userId);
    }
}