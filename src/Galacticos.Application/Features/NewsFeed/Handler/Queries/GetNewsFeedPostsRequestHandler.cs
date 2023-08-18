using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Galacticos.Application.Features.NewsFeed.Request.Queries;
using Galacticos.Application.Persistence.Contracts;

namespace Galacticos.Application.Features.NewsFeed.Handler.Queries
{
    public class GetNewsFeedPostsRequestHandler : IRequestHandler<GetNewsFeedPostsRequest>
    {
        private readonly IMapper _mapper;
        private readonly INewsFeedRepository _newsFeedRepository;
        public GetNewsFeedPostsRequestHandler(IMapper mapper, INewsFeedRepository newsFeedRepository)
        {
            _mapper = mapper;
            _newsFeedRepository = newsFeedRepository;
        }
        public Task<Unit> Handle(GetNewsFeedPostsRequest request, CancellationToken cancellationToken)
        {
            var newsFeedPosts = _newsFeedRepository.GetNewsFeedPosts();
        }
        
    }
}