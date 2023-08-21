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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand,Unit>
    {
        private readonly IPostRepository _iRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository ipost, IMapper map)
        {
            _iRepository = ipost;
            _mapper = map;

        }
        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _iRepository.GetById(request.postDto.Id);
            _mapper.Map(request.postDto, post);

            await _iRepository.Update(post);
            return Unit.Value;
        }
    }
}
