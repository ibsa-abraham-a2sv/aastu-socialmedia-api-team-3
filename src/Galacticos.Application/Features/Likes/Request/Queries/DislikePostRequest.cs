using Galacticos.Application.DTOs.Like;
using MediatR;

namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class DislikePostRequest : IRequest
    {
        public LikeDto likeDto { get; set; } = new LikeDto();   
    }
}