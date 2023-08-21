using Galacticos.Application.DTOs.Like;
using Galacticos.Application.DTOs.Like.Validators;
using MediatR;
using Galacticos.Application.Features.Likes.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
using AutoMapper;
using FluentValidation;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Features.Likes.Handler.Queries
{
    public class LikePostRequestHandler : IRequestHandler<LikePostRequest, Guid>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        
        public LikePostRequestHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(LikePostRequest request, CancellationToken cancellationToken)
        {
            var Validators = new CreateLikeDtoValidator();
            var validation = await Validators.ValidateAsync(request.createLikeDto);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var likes = _mapper.Map<Like>(request.createLikeDto);
            var like = await _likeRepository.LikePost(likes.PostId, likes.UserId);
            return like.Id;
        }
    }
}