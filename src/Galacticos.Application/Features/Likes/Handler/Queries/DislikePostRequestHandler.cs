using AutoMapper;
using MediatR;
using Galacticos.Application.Features.Likes.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.DTOs.Likes.Validators;
using FluentValidation;

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
            var Validators = new LikeDtoValidator();
            var validation = await Validators.ValidateAsync(request.likeDto);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var like = await _likeRepository.GetLikeByPostIdAndUserId(request.likeDto.PostId, request.likeDto.UserId);

            if (like == null)
            {
                throw new Exception("You cannot dislike a post that you have not liked");
            }

            await _likeRepository.UnlikePost(like.PostId, like.UserId);
            return Unit.Value;
        }
    }
}