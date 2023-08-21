using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Request.Commands
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
