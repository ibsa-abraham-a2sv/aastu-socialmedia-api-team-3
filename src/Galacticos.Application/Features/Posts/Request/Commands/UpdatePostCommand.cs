using Galacticos.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Request.Commands
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public PostDto postDto { get; set; }
    }
}
