using ErrorOr;
using Galacticos.Application.DTOs.Like;
using Galacticos.Application.DTOs.Likes;
using MediatR;


namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class LikePostRequest : IRequest<ErrorOr<LikeResponseDto>>
    {
        public CreateLikeDto createLikeDto { get; set; }
    }
}