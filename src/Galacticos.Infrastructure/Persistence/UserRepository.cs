using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Microsoft.VisualBasic;

namespace Galacticos.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        // private readonly _ApiDbContext 
        private readonly List<User> _users = new List<User>();
        //insrte some users
        public UserRepository()
        {
            User user1 = new User()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                UserName = "johndoe",
                Bio = "I am a software engineer",
            };
            User user2 = new User()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane@gmail.com",
                UserName = "janedoe",
                Bio = "I am a software engineer",
            };

            _users.Add(user1);
            _users.Add(user2);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public User EditUser(User user)
        {
            var userToEdit = _users.FirstOrDefault(u => u.Id == user.Id);
            if (userToEdit == null)
            {
                throw new Exception("User not found");
            }

            userToEdit.FirstName = user.FirstName;
            userToEdit.LastName = user.LastName;
            userToEdit.Email = user.Email;
            userToEdit.UserName = user.UserName;
            userToEdit.Bio = user.Bio;
            return userToEdit;
        }

        public User GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(user => user.Email == email);
        }
    }
}