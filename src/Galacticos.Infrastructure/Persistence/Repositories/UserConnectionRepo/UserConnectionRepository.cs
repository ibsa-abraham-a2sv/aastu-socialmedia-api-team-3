using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Galacticos.Infrastructure.Persistence.Repositories.UserConnectionRepo
{
    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly ApiDbContext _dbContext;

        public UserConnectionRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<UserConnection> CreateAsync(UserConnection entity)
        {
            var userConnectionEntry = await _dbContext.Set<UserConnection>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return userConnectionEntry.Entity;
        }

        public async Task<UserConnection> DeleteAsync(Guid userId)
        {
            var userConnection = await _dbContext.Set<UserConnection>().FindAsync(userId);

            if (userConnection != null)
            {
                _dbContext.Set<UserConnection>().Remove(userConnection);
                await _dbContext.SaveChangesAsync();
            }

            return userConnection;
        }

        public async Task<bool> ExistsAsync(Guid userId)
        {
            var userConnection = await _dbContext.userConnections.FindAsync(userId);

            return userConnection != null;
        }

        public async Task<UserConnection> GetUserConnection(Guid userId)
        {
            var userConnection = await _dbContext.userConnections.FirstOrDefaultAsync(uc => uc.userId == userId);

            return userConnection;
        }

        public async Task CleanUpMapping(Guid userId)
        {
            var userConnection = await _dbContext.userConnections.FirstOrDefaultAsync(uc => uc.userId == userId);

            if (userConnection != null)
            {
                _dbContext.userConnections.Remove(userConnection);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
