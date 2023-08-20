using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Moq;
using Xunit;
using Galacticos.Api.Controllers;
using Galacticos.Infrastructure.Data;
using Galacticos.Application.DTOs.Like;
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
                    Id = 1,
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = 1,
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
                    Id = 1,
                    FollowerId = 1,
                    FollowedUserId = 1,
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.LikePost(new CreateLikeDto
                {
                    PostId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.NotNull(result);
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
                    Id = 1,
                    Caption = "Test",
                    Image = "Test",
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                context.users.Add(new User
                {
                    Id = 1,
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
                    Id = 1,
                    FollowerId = 1,
                    FollowedUserId = 1,
                });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new LikeController(new Mock<IMediator>().Object);
                var result = await controller.UnlikePost(new LikeDto
                {
                    PostId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                });
                Assert.NotNull(result);
            }
        }
    }
}