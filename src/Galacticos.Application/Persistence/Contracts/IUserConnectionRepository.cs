using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IUserConnectionRepository
    {
        public Task<UserConnection> CreateAsync(UserConnection entity);
        public Task<UserConnection> DeleteAsync(Guid UserId);
        public Task<bool> ExistsAsync(Guid UserId);
        public Task<UserConnection> GetUserConnection(Guid UserId);
        public Task CleanUpMapping(Guid UserId);
    }
}