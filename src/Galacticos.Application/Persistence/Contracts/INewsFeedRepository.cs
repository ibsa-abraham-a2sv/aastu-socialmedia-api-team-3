using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface INewsFeedRepository : IGenericRepository<object>
    {
        Task<List<object>> GetNewsFeedForUser(int userId, int pageNumber, int pageSize);
    }
}