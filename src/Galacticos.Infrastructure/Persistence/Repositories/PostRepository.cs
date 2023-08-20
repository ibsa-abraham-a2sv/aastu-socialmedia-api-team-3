using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly GalacticoDbContext DbContext;
        public PostRepository(GalacticoDbContext D) : base(D)
        {
            DbContext = D;
        }

        public async Task<Post> Add(Post entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var post = await DbContext.Set<Post>().FindAsync(id);
            await DbContext.Set<Post>().Remove(post);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Post> Get(Guid id)
        {
            return await DbContext.Set<Post>().FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await DbContext.Set<Post>().ToListAsync();
        }

        public async Task<Post> Update(Post entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}
