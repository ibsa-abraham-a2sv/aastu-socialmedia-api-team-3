using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using Galacticos.Domain.Errors;
using AutoMapper;
using Galacticos.Application.DTOs.Comments.Validators;

namespace Galacticos.Application.Features.Comments.Handler.Command
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, ErrorOr<CommentResponesDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public Task<ErrorOr<CommentResponesDTO>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _commentRepository.GetCommentById(request.Id);
            if (comment == null)
            {
                return Task.FromResult<ErrorOr<CommentResponesDTO>>(Errors.Comment.CommentNotFound);
            }

            var validator = new CommentCommandValidator();
            var obj = new CreateCommentRequestDTO()
            {
                Content = request.Content
            };

            var result = validator.Validate(obj);

            if (!result.IsValid)
            {
                return Task.FromResult<ErrorOr<CommentResponesDTO>>(Errors.Comment.InvalidComment);
            }

            comment.Content = request.Content;
            var updatedComment = _commentRepository.UpdateComment(comment);
            var commentResponse = _mapper.Map<CommentResponesDTO>(updatedComment);
            return Task.FromResult<ErrorOr<CommentResponesDTO>>(commentResponse);
        }
    }
}