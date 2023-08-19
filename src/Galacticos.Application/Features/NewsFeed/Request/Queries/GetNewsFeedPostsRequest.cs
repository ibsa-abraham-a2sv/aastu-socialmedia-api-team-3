using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
// using Galacticos.Application.DTOs.Newsfeed;

namespace Galacticos.Application.Features.NewsFeed.Request.Queries
{
    public class GetNewsFeedPostsRequest : IRequest<List<object>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}