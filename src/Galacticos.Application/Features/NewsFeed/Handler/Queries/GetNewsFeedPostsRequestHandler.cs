using AutoMapper;
using MediatR;
using Galacticos.Application.Features.NewsFeed.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
// using Galacticos.Application.DTOs.Newsfeed;

namespace Galacticos.Application.Features.NewsFeed.Handler.Queries
{
    public class GetNewsFeedPostsRequestHandler : IRequestHandler<GetNewsFeedPostsRequest, List<object>>
    {
        private readonly IMapper _mapper;
        private readonly INewsFeedRepository _newsFeedRepository;
        public GetNewsFeedPostsRequestHandler(IMapper mapper, INewsFeedRepository newsFeedRepository)
        {
            _mapper = mapper;
            _newsFeedRepository = newsFeedRepository;
        }
        public async Task<List<object>> Handle(GetNewsFeedPostsRequest request, CancellationToken cancellationToken)
        {
            var newsFeedPosts = await _newsFeedRepository.GetNewsFeedForUser(request.Id);
            return _mapper.Map<List<object>>(newsFeedPosts);
        }   
    }
}