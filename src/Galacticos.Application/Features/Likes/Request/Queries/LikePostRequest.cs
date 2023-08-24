using Galacticos.Application.DTOs.Likes;
using MediatR;


namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class LikePostRequest : IRequest<Guid>
    {
        public CreateLikeDto createLikeDto { get; set; }
    }
}