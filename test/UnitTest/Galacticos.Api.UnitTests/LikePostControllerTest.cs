// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Abstractions;
// using Moq;
// using Xunit;
// using Galacticos.Api.Controllers;
// using Galacticos.Infrastructure.Data;
// using Galacticos.Domain.Entities;

// namespace Galacticos.Test.Api.UnitTests
// {
//     public class LikePostControllerTest
//     {
//         public DbContextOptions<ApiDbContext> CreateContext()
//         {
//             return new DbContextOptionsBuilder<ApiDbContext>()
//                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//                 .Options;
//         }


//         [Fact]
//         public async Task LikePostReturnsOkResult()
//         {
//             // Arrange
//             var options = CreateContext();

//             using (var context = new ApiDbContext(options))
//             {
//                 context.Posts.Add(new Post
//                 {
//                     Id = 1,
//                     Content = "Test",
//                     Date = DateTime.Now,
//                     UserId = 1
//                 });
//                 context.users.Add(new User
//                 {
//                     Id = 1,
//                     Name = "Test",
//                     Email = "",
//                     Password = "123456",
//                     Posts = new List<Post>()
//                 });
//                 context.SaveChanges();
//             }

//             using (var context = new ApiDbContext(options))
//             {
//                 var controller = new LikeController(context);
//                 var result = await controller.LikePost(1, 1);
//                 Assert.NotNull(result);
//             }
//         }
//     }
// }