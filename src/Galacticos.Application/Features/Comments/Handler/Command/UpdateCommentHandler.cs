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
        public async Task<ErrorOr<CommentResponesDTO>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetCommentById(request.CommentId);
            if(comment == null)
            {
                return new ErrorOr<CommentResponesDTO>().Errors;
            }
            var commentToUpdate = _mapper.Map(request, comment);
            var updatedComment = await _commentRepository.UpdateComment(commentToUpdate);
            return _mapper.Map<CommentResponesDTO>(updatedComment);   
        }
    }
}