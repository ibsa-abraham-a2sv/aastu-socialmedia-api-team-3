using Galacticos.Application.DTOs.Likes;
using Galacticos.Application.DTOs.Likes.Validators;
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
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        
        public LikePostRequestHandler(ILikeRepository likeRepository, IMapper mapper, IUserRepository userRepository, IPostRepository postRepository)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(LikePostRequest request, CancellationToken cancellationToken)
        {
            var Validators = new CreateLikeDtoValidator();
            var validation = await Validators.ValidateAsync(request.createLikeDto);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var user = _userRepository.GetUserById(request.createLikeDto.UserId);

            if (user == null)
            {
                throw new ValidationException("User does not exist");
            }

            var post = _postRepository.GetById(request.createLikeDto.PostId);

            if (post == null)
            {
                throw new ValidationException("Post does not exist");
            }

            var likes = _mapper.Map<Like>(request.createLikeDto);
            var like = await _likeRepository.LikePost(likes.PostId, likes.UserId);
            return like.Id;
        }
    }
}