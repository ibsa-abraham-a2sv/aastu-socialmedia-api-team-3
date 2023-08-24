using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Comments.Request.Commands;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Domain.Errors;
using MediatR;

namespace Galacticos.Application.Features.Posts.Handlers.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<PostResponesDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<ErrorOr<PostResponesDTO>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);

            var postResult = await _postRepository.Add(post);

            if (postResult == null)
            {
                return new ErrorOr<PostResponesDTO>().Errors; // Assuming this returns an ErrorOr instance with appropriate error
            }


            var response = _mapper.Map<PostResponesDTO>(postResult);
            return response;
        }
    }
}