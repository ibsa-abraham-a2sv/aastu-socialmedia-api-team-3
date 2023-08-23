using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Galacticos.Api.Controllers;
using Galacticos.Infrastructure.Data;
using Galacticos.Application.DTOs.Likes;
using Galacticos.Domain.Entities;
using MediatR;

namespace Galacticos.Test.Api.UnitTests
{
    public class LikePostControllerTest
    {
        public DbContextOptions<ApiDbContext> CreateContext()
        {
            return new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }


        [Fact]
        public async Task LikePostReturnsOkResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task LikePostwithNoPostReturnsNotFoundResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Fact]
        public async Task LikePostwithNoUserReturnsNotFoundResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Fact]
        public async Task LikePostwithNoRelationReturnsNotFoundResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Fact]
        public async Task LikePostwithNoPostIdReturnsBadRequestResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = new Guid(),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.IsType<BadRequestObjectResult>(result);
            }
        }

        [Fact]
        public async Task LikePostwithNoUserIdReturnsBadRequestResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid(),
                });
                Assert.IsType<BadRequestObjectResult>(result);
            }
        }


        [Fact]
        public async Task UnlikePostReturnsOkResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.UnlikePost(new LikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task UnlikePostwithNoPostReturnsNotFoundResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FirstName = "Test",
                    LastName = "Test",
                    UserName = "Test",
                    Email = "Test",
                    Password = "Test",
                    Bio = "Test",
                    Picture = "Test",
                    
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.UnlikePost(new LikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Fact]
        public async Task UnlikePostwithNoUserReturnsNotFoundResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                
                context.relations.Add(new Follow
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });

                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.UnlikePost(new LikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Fact]
        public async Task UnlikePostwithNoRelationReturnsNotFoundResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000")
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000")
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.UnlikePost(new LikeDto
                {
                    PostId = new Guid("00000000-0000-0000-0000-000000000000"),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000")
                });
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Fact]
        public async Task UnlikePostwithNoPostIdReturnsBadRequestResult()
        {
            // Arrange
            var options = CreateContext();

            using (var context = new ApiDbContext(options))
            {
                context.posts.Add(new Post
                {
                    Id = new Guid(),
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000")
                });
                context.users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000")
                });
                context.relations.Add(new Follow
                {
                    Id = new Guid(),
                    FollowerId = new Guid("00000000-0000-0000-0000-000000000000"),
                    FollowedUserId = new Guid("00000000-0000-0000-0000-000000000000")
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);

                var result = await controller.UnlikePost(new LikeDto
                {
                    PostId = new Guid(),
                    UserId = new Guid("00000000-0000-0000-0000-000000000000")
                });
                Assert.IsType<BadRequestObjectResult>(result);
            }
        }
    }
}