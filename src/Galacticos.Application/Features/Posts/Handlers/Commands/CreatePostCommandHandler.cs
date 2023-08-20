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

namespace Galacticos.Application.Features.Posts.Handlers.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository ipostRepository, IMapper imapper)
        {
            _repository = ipostRepository;
            _mapper = imapper;
        }
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var posts = _mapper.Map<Post>(request.postDto);
            posts = await _repository.Add(posts);

            return posts.Id;
        }
    }
}
