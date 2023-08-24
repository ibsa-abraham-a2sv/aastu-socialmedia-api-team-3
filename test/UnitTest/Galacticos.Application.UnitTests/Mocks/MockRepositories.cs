using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Moq;

namespace Galacticos.Application.UnitTests.Mocks
{
    public class MockRepositories
    {
        // public static Mock<ILikeRepository> LikeRepository()
        // {

        //     var Likes = new List<Like>
        //     {
        //         new Like
        //         {
        //             Id = new Guid("00000000-0000-0000-0000-000000000000"),
        //             UserId = new Guid("00000000-0000-0000-0000-000000000000"),
        //             PostId = new Guid("00000000-0000-0000-0000-000000000000"),
        //         }
        //     };


        //     var mockRepo = new Mock<ILikeRepository>();
        //     mockRepo.Setup(repo => repo.LikePost(It.IsAny<Guid>(), It.IsAny<Guid>()))
        //            .ReturnsAsync((Guid postId, Guid userId) => new Like { Id = Guid.NewGuid() });

        //     return mockRepo;
        // }


        public static Mock<IUserRepository> UserRepository()
        {
            var Users = new List<User>
            {
                new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "jhondoe",
                    Password = "123456",
                    Bio = "I am a software developer",
                    Picture = "picture.jpg",
                }
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetUserById(It.IsAny<Guid>()))
                    .Returns((Guid id) => Users.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(repo => repo.GetUserByEmail(It.IsAny<string>()))
                    .Returns((string email) => Users.FirstOrDefault(x => x.Email == email));

            mockRepo.Setup(repo => repo.GetUserByUserName(It.IsAny<string>()))
                    .Returns((string userName) => Users.FirstOrDefault(x => x.UserName == userName));

            mockRepo.Setup(repo => repo.AddUser(It.IsAny<User>()))
                    .Callback((User user) => Users.Add(user));

            mockRepo.Setup(repo => repo.EditUser(It.IsAny<User>()))
                    .Returns((User user) => user);
                    
            mockRepo.Setup(repo => repo.GetAllUsers())
                    .Returns(() => Users);
            
            return mockRepo;
        }


        public static Mock<IJwtTokenGenerator> GetJwtTokenGenerator()
        {
            var Token = new List<string>
            {
                "your_valid_jwt_token_here"
            };

            var jwtRepo = new Mock<IJwtTokenGenerator>();

            // vajwtRepo = new Mock<IJwtTokenGenerator>();
            jwtRepo.Setup(generator => generator.GenerateToken(It.IsAny<User>()))
                        .Returns("your_valid_jwt_token_here");
            
            return jwtRepo;
        }
    }
}