using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Galacticos.Infrastructure.Repositories.RelationRepo
{
    public class RelationRepository : IRelationRepository
    {
        private readonly ApiDbContext _context;
        public RelationRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Follow> Follow(Guid followerId, Guid followingId)
        {
            var follow = new Follow
            {
                FollowerId = followerId,
                FollowedUserId = followingId
            };

            await _context.relations.AddAsync(follow);
            await _context.SaveChangesAsync();

            return follow;
        }

        public async Task<Follow> UnFollow(Guid followerId, Guid followingId)
        {
            var unfollow = await _context.relations.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedUserId == followingId);

            if (unfollow != null)
            {
                _context.relations.Remove(unfollow);
                await _context.SaveChangesAsync();
            }

            return unfollow!;
        }

        public async Task<Follow> Get(Guid followerId, Guid followingId)
        {
            var res = await _context.relations.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedUserId == followingId);
            return res!;
        }

        public async Task<List<Guid>> GetAllFollowedIdsByUserId(Guid id)
        {
            var followedIds = await _context.relations
                .Where(f => f.FollowerId == id)
                .Select(f => f.FollowedUserId)
                .ToListAsync();

            return followedIds;
        }

    }
}