using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Moq;

namespace Galacticos.Application.UnitTests.Mocks
{
    public class MockRepositories
    {
        public static Mock<ILikeRepository> GetLikeRepository()
        {
            var Users = new List<User>
            {
                new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                }
            };

            var Posts = new List<Post>
            {
                new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                }
            };

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
            mockRepo.Setup(repo => repo.LikePost(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync((Guid postId, Guid userId) =>
            {
                var like = new Like
                {
                    UserId = userId,
                    PostId = postId
                };

                Likes.Add(like);
                return like;
            });
            mockRepo.Setup(repo => repo.UnlikePost(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync((Guid postId, Guid userId) =>
            {
                var like = Likes.FirstOrDefault(l => l.PostId == postId && l.UserId == userId);
                Likes.Remove(like);
                return like;
            });

            return mockRepo;

        }
    }
}