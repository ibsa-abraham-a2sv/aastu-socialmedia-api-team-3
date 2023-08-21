using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;
using Galacticos.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Galacticos.Persistence.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApiDbContext _context;
        public LikeRepository(ApiDbContext context)
        {
            _context = context;
        }

        // public async Task<Like> LikePost(Guid postId, Guid userId)
        // {
        //     var like = new Like
        //     {
        //         UserId = userId,
        //         PostId = postId
        //     };

        //     await _context.Likes.Add(like);
        //     await _context.SaveChangesAsync();

        //     return like;
        // }

        // public async Task<Like> GetLikeByPostIdAndUserId(Guid postId, Guid userId)
        // {
        //     return await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        // }

        // public async Task<Like> UnlikePost(Guid postId, Guid userId)
        // {
        //     var like = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        //     _context.Likes.Remove(like);
        //     await _context.SaveChangesAsync();

        //     return like;
        // }
        public Guid Add(Like entity)
        {
            _context.likes.Add(entity);
            if (_context.SaveChanges() == 0)
            {
                throw new Exception("Error saving like");
            }
            return entity.Id;
        }

        public void Delete(Like entity)
        {
            _context.likes.Remove(entity);
            if (_context.SaveChanges() == 0)
            {
                throw new Exception("Error deleting like");
            }
        }

        public Task<List<Like>> GetAll()
        {
            return _context.likes.ToListAsync();
        }

        public Task<Like> GetById(Guid id)
        {
            return _context.likes.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Like> GetLikeByPostIdAndUserId(Guid postId, Guid userId)
        {
            return await _context.likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        }

        public async Task<Like> LikePost(Guid postId, Guid userId)
        {
            var like = new Like
            {
                UserId = userId,
                PostId = postId
            };

            _context.likes.Add(like);
            if (await _context.SaveChangesAsync() == 0)
            {
                throw new Exception("Error saving like");
            }
            return like;
        }

        public async Task<Like> UnlikePost(Guid postId, Guid userId)
        {
            var like = await _context.likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
            _context.likes.Remove(like);
            await _context.SaveChangesAsync();

            return like;
        }

        public Task Update(Like entity)
        {
            throw new NotImplementedException();
        }
    }
}