using Galacticos.Application.DTOs.Posts;
using MediatR;

namespace Galacticos.Application.Features.Posts.Request.Queries
{
    public class GetPostsLikedByUserRequest : IRequest<List<GetPostDto>>
    {
        public Guid UserId { get; set; }
    }
}