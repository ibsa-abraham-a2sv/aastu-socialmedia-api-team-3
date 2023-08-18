using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Galacticos.Application.Features.NewsFeed.Request.Queries
{
    public class GetNewsFeedPostsRequest : IRequest
    {
        public int UserId { get; set; }
        
    }
}