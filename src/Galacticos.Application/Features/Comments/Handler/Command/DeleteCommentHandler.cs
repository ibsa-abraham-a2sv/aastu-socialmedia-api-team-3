using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Errors;
using MediatR;

namespace Galacticos.Application.Features.Comments.Handler.Command
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentRequest, ErrorOr<CommentResponesDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public DeleteCommentHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public Task<ErrorOr<CommentResponesDTO>> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = _commentRepository.GetCommentById(request.Id);
            if (comment == null)
            {
                return Task.FromResult<ErrorOr<CommentResponesDTO>>(Errors.Comment.CommentNotFound);
            }
            _commentRepository.DeleteComment(comment);
            var commentResponse = _mapper.Map<CommentResponesDTO>(comment);
            return Task.FromResult<ErrorOr<CommentResponesDTO>>(commentResponse);
        }
    }
}