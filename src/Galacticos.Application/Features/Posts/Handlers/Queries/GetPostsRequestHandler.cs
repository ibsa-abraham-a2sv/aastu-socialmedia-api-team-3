using AutoMapper;
using Galacticos.Application.Features.Posts.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.DTOs.Posts;

namespace Galacticos.Application.Features.Posts.Handlers.Queries
{
    public class GetPostsRequestHandler : IRequestHandler<GetPostsRequest, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<PostDto>> Handle(GetPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();
            return _mapper.Map<List<PostDto>>(posts);
        }

    }
}
