using ErrorOr;
using Galacticos.Application.DTOs.Like;
using Galacticos.Application.DTOs.Likes;
using MediatR;

namespace Galacticos.Application.Features.Likes.Command.Queries
{
    public class DislikePostRequest : IRequest<ErrorOr<bool>>
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}