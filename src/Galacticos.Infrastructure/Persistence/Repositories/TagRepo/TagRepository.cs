using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Galacticos.Infrastructure.Persistence.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApiDbContext _dbContext;

        public TagRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tag> GetById(Guid id)
        {
            return await _dbContext.tags.FindAsync(id);
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _dbContext.tags.ToListAsync();
        }

        public async Task<Tag> Add(Tag tag)
        {
            _dbContext.tags.Add(tag);
            await _dbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> Update(Tag tag)
        {
            _dbContext.Entry(tag).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tag;
        }

        public async Task Delete(Guid id)
        {
            var tag = await _dbContext.tags.FindAsync(id);
            _dbContext.tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _dbContext.tags.AnyAsync(tag => tag.Id == id);
        }

        public async Task<List<Tag>> GetTagsByPost(Guid postId)
        {
            var tags = await _dbContext.postTags
                .Where(pt => pt.PostId == postId)
                .Select(pt => pt.Tag)
                .ToListAsync();

            return tags;
        }

        public async Task<List<Tag>> SearchTags(string searchTerm)
        {
            var tags = await _dbContext.tags
                .Where(tag => tag.Name.Contains(searchTerm))
                .ToListAsync();

            return tags;
        }
    }
}
