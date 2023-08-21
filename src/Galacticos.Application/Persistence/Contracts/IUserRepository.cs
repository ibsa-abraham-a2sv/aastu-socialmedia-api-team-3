using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IUserRepository
    {
        User? GetUserById(Guid id);
        void AddUser(User user);
        User EditUser(User user);
        User GetUserByEmail(string email);
    }
}