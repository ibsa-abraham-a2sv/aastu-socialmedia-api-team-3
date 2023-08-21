using MediatR;
using Galacticos.Application.DTOs.Posts;

namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class GetPostsLikedByUserRequest : IRequest<List<PostDto>>
    {
        public Guid UserId { get; set; }
        
    }
}