using AutoMapper;
using ErrorOr;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Handlers.Commands
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, ErrorOr<PostResponesDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<ErrorOr<PostResponesDTO>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetById(request.PostId);

            if (post == null)
            {
                return new ErrorOr<List<PostResponesDTO>>().Errors;
            }

            var postToUpdate = _mapper.Map(request.UpdatePostRequestDTO, post);

            var updatedPost = await _postRepository.Update(postToUpdate);
            
            
            var postResponseDTO = _mapper.Map<PostResponesDTO>(updatedPost);

            return postResponseDTO;

        }
    }
}
