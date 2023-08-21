using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;

namespace Galacticos.Infrastructure.Persistence.Repositories.RelationRepo
{
    public class RelationRepository : IRelationRepository
    {
        public Guid Add(Follow entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Follow entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Follow>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Follow> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> GetFollowedUserIdsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Follow entity)
        {
            throw new NotImplementedException();
        }
    }
}