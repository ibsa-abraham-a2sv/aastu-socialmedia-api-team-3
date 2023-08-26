using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.DTOs.Comments.Validators;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using MediatR;

namespace Galacticos.Application.Features.Comments.Handler.Command
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, ErrorOr<CommentResponesDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateCommentHandler(
            ICommentRepository commentRepository,
            IMapper mapper,
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<CommentResponesDTO>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CommentCommandValidator();

            var obj = new CreateCommentRequestDTO()
            {
                Content = request.Content
            };

            var result = validator.Validate(obj);

            if (!result.IsValid)
            {
                return new ErrorOr<CommentResponesDTO>().Errors;
            }

            var user = await _userRepository.Exists(request.UserId);
            var post = await _postRepository.GetById(request.PostId);

            if (!user || post == null)
            {
                return new ErrorOr<CommentResponesDTO>().Errors;
            }

            var comment = _mapper.Map<Comment>(request);
            ErrorOr<CommentResponesDTO> res = _commentRepository.CreateComment(comment);
            return res;
        }
    }
}