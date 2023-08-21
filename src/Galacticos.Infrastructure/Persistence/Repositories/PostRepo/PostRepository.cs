using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;

namespace Galacticos.Infrastructure.Persistence.Repositories.PostRepo
{
    public class PostRepository : IPostRepository
    {
        public Guid Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsLikedByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}