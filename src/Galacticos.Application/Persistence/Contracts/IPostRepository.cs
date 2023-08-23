using Galacticos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Galacticos.Application.Persistence.Contracts
{
    public interface IPostRepository
    {
        Task<Post> GetById(Guid id);
        Task<List<Post>> GetAll();
        Task<Post> Add(Post entity);
        Task<Post> Update(Post entity);
        Task Delete(Guid id);
        Task<bool> Exists(Guid id);
        Task<List<Post>> GetPostsByUserId(Guid userId);
        Task<List<Post>> GetPostsLikedByUser(Guid userId);
        Task<List<Post>> GetPostsByTag(Guid tagId); 
    }
}