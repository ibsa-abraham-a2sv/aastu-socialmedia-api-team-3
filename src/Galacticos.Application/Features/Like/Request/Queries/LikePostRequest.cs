using Galacticos.Application.DTOs.Like;
using MediatR;


namespace Galacticos.Application.Features.Like.Request.Queries
{
    public class LikePostRequest : IRequest<LikeDto>
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}