using Galacticos.Application.DTOs.Like;
using MediatR;
using Galacticos.Application.Features.Like.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
using AutoMapper;

namespace Galacticos.Application.Features.Like.Handler.Queries
{
    public class LikePostRequestHandler : IRequestHandler<LikePostRequest, LikeDto>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        
        public LikePostRequestHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<LikeDto> Handle(LikePostRequest request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.LikePost(request.UserId, request.PostId);
            return _mapper.Map<LikeDto>(like);
        }
    }
}