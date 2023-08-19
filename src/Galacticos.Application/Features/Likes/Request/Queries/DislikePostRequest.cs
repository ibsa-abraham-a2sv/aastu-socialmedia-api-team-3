using MediatR;

namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class DislikePostRequest : IRequest
    {
        public int UserId { get; set; }
        public int PostId { get; set; }   
    }
}