using MediatR;

namespace Galacticos.Application.Features.NewsFeed.Request.Queries
{
    public class GetNewsFeedPostsRequest : IRequest<List<object>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}