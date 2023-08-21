using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IRelationRepository : IGenericRepository<Follow>
    {
        Task<List<int>> GetFollowedUserIdsByUserId(int userId);   
    }
}