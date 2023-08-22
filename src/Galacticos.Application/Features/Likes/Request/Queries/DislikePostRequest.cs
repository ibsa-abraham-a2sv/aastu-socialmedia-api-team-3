using Galacticos.Application.DTOs.Likes;
using MediatR;

namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class DislikePostRequest : IRequest<Unit>
    {
        public LikeDto likeDto { get; set; } = new LikeDto();   
    }
}