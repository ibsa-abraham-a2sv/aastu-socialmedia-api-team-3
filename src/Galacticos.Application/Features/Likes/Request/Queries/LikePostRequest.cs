using Galacticos.Application.DTOs.Likes;
using MediatR;


namespace Galacticos.Application.Features.Likes.Request.Queries
{
    public class LikePostRequest : IRequest<Guid>
    {
        private CreateLikeDto createLikeDto1;

        public LikePostRequest(CreateLikeDto createLikeDto1)
        {
            this.createLikeDto1 = createLikeDto1;
        }

        public CreateLikeDto createLikeDto { get; set; } = new CreateLikeDto();
    }
}