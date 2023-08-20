using AutoMapper;
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
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository ipostRepository, IMapper imapper)
        {
            _repository = ipostRepository;
            _mapper = imapper;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _repository.Get(request.Id);
            await _repository.Delete(post.Id);

            return Unit.Value;
        }
    }
}
