using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;

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

            var relation = await _context.relations.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedUserId == followingId);

            if (relation == null)
            {
                await _context.relations.AddAsync(follow);
                await _context.SaveChangesAsync();

                return follow;
            }

            return null;
        }

        public async Task<Follow> UnFollow(Guid followerId, Guid followingId)
        {
            var unfollow = await _context.relations.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedUserId == followingId);

            if (unfollow != null)
            {
                _context.relations.Remove(unfollow);
                await _context.SaveChangesAsync();

                return unfollow;
            }

            return null;
        }

        public async Task<Follow> Get(Guid followerId, Guid followingId)
        {
            var res = await _context.relations.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedUserId == followingId);
            return res;
        }

        public async Task<List<Guid>> GetAllFollowedIdsByUserId(Guid id)
        {
            var followedIds = await _context.relations
                .Where(f => f.FollowerId == id)
                .Select(f => f.FollowedUserId)
                .ToListAsync();

            return followedIds;
        }

        public async Task<List<Guid>> GetAllFollowersId(Guid id)
        {
            var followersIds = await _context.relations
                .Where(f => f.FollowedUserId == id)
                .Select(f => f.FollowerId)
                .ToListAsync();

            return followersIds;
        }

    }
}