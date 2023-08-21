using Galacticos.Application.DTOs.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Request.Queries
{
    public class GetPostDetailRequest : IRequest<PostDto>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
