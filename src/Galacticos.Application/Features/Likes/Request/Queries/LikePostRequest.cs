using Galacticos.Application.DTOs.Like;
using MediatR;


namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class LikePostRequest : IRequest<int>
    {
        public CreateLikeDto createLikeDto { get; set; } = new CreateLikeDto();
    }
}