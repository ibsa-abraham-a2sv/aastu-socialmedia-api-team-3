using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using MediatR;

namespace Galacticos.Application.Features.Comments.Handler.Command
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, ErrorOr<CommentResponesDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateCommentHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<ErrorOr<CommentResponesDTO>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            var result = await _commentRepository.CreateComment(comment);
            if(result == null)
            {
                return new ErrorOr<CommentResponesDTO>().Errors;
            }
            var response = _mapper.Map<CommentResponesDTO>(result);
            return response;
        }
    }
}