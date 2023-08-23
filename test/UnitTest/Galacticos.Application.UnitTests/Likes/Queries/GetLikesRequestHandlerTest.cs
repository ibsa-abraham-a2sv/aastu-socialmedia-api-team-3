using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Galacticos.Application.Persistence.Contracts;
using Moq;
using Galacticos.Application.UnitTests.Mocks;
using Galacticos.Application.Features.Likes.Handler.Queries;
using Galacticos.Application.Features.Likes.Request.Queries;
using Galacticos.Application.DTOs.Likes;
using Xunit;
using MediatR;

namespace Galacticos.Application.UnitTests.Likes.Queries
{
    public class GetLikesRequestHandlerTest
    {
        private readonly Mock<ILikeRepository> _likeRepository;
        private readonly IMapper _mapper;

        public GetLikesRequestHandlerTest()
        {
            _likeRepository = MockRepositories.GetLikeRepository();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles.LikeMappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLikesRequestHandler_Success()
        {
            var handler = new LikePostRequestHandler(_likeRepository.Object, _mapper);

            var result = await handler.Handle(new LikePostRequest(), CancellationToken.None);

            Assert.IsType<Guid>(result);
        }
    }
}