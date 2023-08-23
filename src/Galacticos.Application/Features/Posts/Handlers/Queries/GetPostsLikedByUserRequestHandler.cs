using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Posts.Request.Queries;

namespace Galacticos.Application.Features.Posts.Handlers.Queries
{
    public class GetPostsLikedByUserRequestHandler : IRequestHandler<GetPostsLikedByUserRequest, List<GetPostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostsLikedByUserRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public Task<List<GetPostDto>> Handle(GetPostsLikedByUserRequest request, CancellationToken cancellationToken)
        {
            var posts = _postRepository.GetPostsLikedByUser(request.UserId);
            var postsDto = _mapper.Map<List<GetPostDto>>(posts);
            return Task.FromResult(postsDto);
        }
    }
}