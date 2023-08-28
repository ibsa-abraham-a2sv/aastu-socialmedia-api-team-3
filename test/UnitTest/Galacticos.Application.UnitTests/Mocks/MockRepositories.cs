using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Moq;

namespace Galacticos.Application.UnitTests.Mocks
{
    public class MockRepositories
    {
        public static Mock<IPostRepository> PostRepository()
        {
            var Posts = new List<Post>
            {
                new Post{
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                    Caption = "Test",
                    Image = "Test.png",
                },
                new Post{
                    Id = new Guid("11111111-0000-0000-0000-000000000000"),
                    UserId = new Guid( "22222222-2222-2222-2222-222222222222"),
                    Caption = " Test 2",
                    Image = "Test2.png"
                }
            };

            var mock = new Mock<IPostRepository>(); 
            
            mock.Setup(r => r.GetAll()).ReturnsAsync(Posts);
            
            mock.Setup(r => r.Add(It.IsAny<Post>()))
                .Callback((Post post) => Posts.Add(post));

            mock.Setup(r => r.GetById(It.IsAny<Guid>())).Returns((Guid postId) => Posts.FirstOrDefault(x => x.Id == postId));

            return mock;
        }
        
        public static Mock<ILikeRepository> LikeRepository()
        {

            var Likes = new List<Like>
            {
                new Like
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                }
            };


            var mockRepo = new Mock<ILikeRepository>();
            mockRepo.Setup(repo => repo.LikePost(It.IsAny<Guid>(), It.IsAny<Guid>()))
                   .ReturnsAsync((Guid postId, Guid userId) => new Like { Id = Guid.NewGuid() });

            return mockRepo;
        }


        public static Mock<IUserRepository> UserRepository()
        {
            var Users = new List<User>
            {
                new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "jhondoe",
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
            mockRepo.Setup(repo => repo.GetUserByIdentifier(It.IsAny<string>()))
                    .Returns((string identifier) => Users.FirstOrDefault(x => x.UserName == identifier || x.Email == identifier));
            
            return mockRepo;
        }


        public static Mock<IJwtTokenGenerator> GetJwtTokenGenerator()
        {
            var Token = new List<string> { "your_valid_jwt_token_here" };

            var jwtRepo = new Mock<IJwtTokenGenerator>();
            jwtRepo.Setup(generator => generator.GenerateToken(It.IsAny<User>()))
                        .Returns("your_valid_jwt_token_here");
            
            return jwtRepo;
        }


        public static Mock<ICommentRepository> CommentRepository()
        {
            var Comments = new List<Comment>
            {
                new Comment
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    Content = "This is a comment",
                }
            };

            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(repo => repo.CreateComment(It.IsAny<Comment>()))
                .Callback((Comment comment) => Comments.Add(comment))
                .Returns((Comment comment) => new CommentResponesDTO
                    {
                        Id = comment.Id,
                        UserId = comment.UserId,
                        PostId = comment.PostId,
                        Content = comment.Content,
                    });
                

            mockRepo.Setup(repo => repo.UpdateComment(It.IsAny<Comment>()))
                    .Returns((Comment comment) => new CommentResponesDTO
                    {
                        Id = comment.Id,
                        UserId = comment.UserId,
                        PostId = comment.PostId,
                        Content = comment.Content,
                    });

            mockRepo.Setup(repo => repo.GetCommentById(It.IsAny<Guid>()))
                    .Returns((Guid id) => Comments.FirstOrDefault(x => x.Id == id));

            return mockRepo;
        }

        public static Mock<IRelationRepository> RelationRepository()
        {
            var Relations = new List<Follow>
            {
                new Follow
                {
                    FollowerId = new Guid("11111111-1111-1111-1111-111111111111"),
                    FollowedUserId = new Guid("22222222-2222-2222-2222-222222222222"),
                }
            };

            var mockRepo = new Mock<IRelationRepository>();

            mockRepo.Setup(repo => repo.Follow(It.IsAny<Guid>(), It.IsAny<Guid>()))
                    .ReturnsAsync((Guid followerId, Guid followedUserId) => new Follow
                    {
                        FollowerId = followerId,
                        FollowedUserId = followedUserId,
                    });

            
            mockRepo.Setup(repo => repo.UnFollow(It.IsAny<Guid>(), It.IsAny<Guid>()))
                    .ReturnsAsync((Guid followerId, Guid followedUserId) => new Follow
                    {
                        FollowerId = followerId,
                        FollowedUserId = followedUserId,
                    });
            
            mockRepo.Setup(repo => repo.Get(It.IsAny<Guid>(), It.IsAny<Guid>()))
                    .ReturnsAsync((Guid followerId, Guid followedUserId) => new Follow
                    {
                        FollowerId = followerId,
                        FollowedUserId = followedUserId,
                    });

            return mockRepo;
        }


        public static Mock<IUserRepository> ProfileRepository()
        {
            var Users = new List<User>
            {
                new User
                {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "jhondoe",
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
    }
}