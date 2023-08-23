using ErrorOr;
using Galacticos.Application.DTOs.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Request.Commands
{
    public class CreatePostCommand : IRequest<ErrorOr<PostResponesDTO>>
    { 
        public string Caption {get; set;} = null!;
        public string Image {get; set;}
        public Guid UserId {get; set;}
        public List<string> Tags {get; set;} = new List<string>();
    }
}
