using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.Features.Comments.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using Galacticos.Domain.Errors;

namespace Galacticos.Application.Features.Comments.Handler.Query
{
    public class GetCommentsByPostIdRequestHandler : IRequestHandler<GetCommentsByPostIdRequest, ErrorOr<List<CommentResponesDTO>>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetCommentsByPostIdRequestHandler(ICommentRepository commentRepository, IMapper mapper, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public Task<ErrorOr<List<CommentResponesDTO>>> Handle(GetCommentsByPostIdRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("GetCommentsByPostIdRequestHandler");
            var post = _postRepository.GetById(request.PostId);
            if (post == null)
            {
                return Task.FromResult<ErrorOr<List<CommentResponesDTO>>>(Errors.Post.PostNotFound);
            }

            List<CommentResponesDTO> comments = _commentRepository.GetCommentsByPostId(request.PostId);
            // var commentResponses = _mapper.Map<List<CommentResponesDTO>>(comments);

            return Task.FromResult<ErrorOr<List<CommentResponesDTO>>>(comments);
        }
    }
}