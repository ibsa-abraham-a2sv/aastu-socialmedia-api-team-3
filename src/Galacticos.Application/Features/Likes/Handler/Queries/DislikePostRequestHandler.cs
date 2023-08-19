using AutoMapper;
using MediatR;
using Galacticos.Application.Features.Likes.Request.Queries;
using Galacticos.Application.Persistence.Contracts;

namespace Galacticos.Application.Features.Likes.Handler.Queries
{
    public class DislikePostRequestHandler : IRequestHandler<DislikePostRequest, Unit>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public DislikePostRequestHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DislikePostRequest request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetLikeByPostIdAndUserId(request.PostId, request.UserId);

            if (like == null)
            {
                throw new Exception("You cannot dislike a post that you have not liked");
            }

            await _likeRepository.Delete(like);

            return Unit.Value;
        }
    }
}