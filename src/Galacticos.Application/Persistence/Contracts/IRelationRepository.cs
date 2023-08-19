using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IRelationRepository : IGenericRepository<Relation>
    {
        Task<List<int>> GetFollowedUserIdsByUserId(int userId);   
    }
}