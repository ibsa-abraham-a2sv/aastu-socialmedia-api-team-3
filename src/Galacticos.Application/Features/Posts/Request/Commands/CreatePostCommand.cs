using Galacticos.Application.DTOs.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Request.Commands
{
    public class CreatePostCommand : IRequest<Guid>
    { 
        public PostDto postDto { get; set; }
    }
}
