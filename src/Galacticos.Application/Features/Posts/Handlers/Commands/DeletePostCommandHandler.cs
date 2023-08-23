using AutoMapper;
using Galacticos.Application.Features.Posts.Request.Commands;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using Galacticos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Galacticos.Application.Features.Posts.Handlers.Commands
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, ErrorOr<bool>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<bool>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Post postToDelete = await _postRepository.GetById(request.PostId);

            if (postToDelete == null)
            {
                return new ErrorOr<bool>().Errors;
            }

            if (postToDelete.UserId != request.UserId)
            {
                return new ErrorOr<bool>().Errors;
            }

            bool result = await _postRepository.Delete(request.PostId);

            return result;
        }
    }
}
