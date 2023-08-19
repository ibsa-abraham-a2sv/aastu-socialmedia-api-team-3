using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Galacticos.Persistence.Repositories
{
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        private readonly SocialMediaDbContext _context;
        public LikeRepository(SocialMediaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Like> LikePost(int userId, int postId)
        {
            var like = new Like
            {
                UserId = userId,
                PostId = postId
            };

            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();

            return like;
        }

        public async Task<Like> GetLikeByPostIdAndUserId(int postId, int userId)
        {
            return await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        }
    }
}