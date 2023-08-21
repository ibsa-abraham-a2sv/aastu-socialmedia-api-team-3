using Galacticos.Application.DTOs.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Request.Queries
{
    public class GetPostsRequest : IRequest<List<PostDto>>
    {
        
    }
}