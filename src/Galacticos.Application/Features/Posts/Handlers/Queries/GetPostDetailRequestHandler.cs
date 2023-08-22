using AutoMapper;
using Galacticos.Application.DTOs.Posts;
using Galacticos.Application.Features.Posts.Request.Queries;
using Galacticos.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.Features.Posts.Handlers.Queries
{
    public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, GetPostDto>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _iPostRepository;
        public GetPostDetailRequestHandler(IPostRepository ipostRepository, IMapper mapper)
        {
            _iPostRepository = ipostRepository;
            _mapper = mapper;
        }
        public async Task<GetPostDto> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
        {
            var comments = await _iPostRepository.GetById(request.Id);
            return _mapper.Map<GetPostDto>(comments);
        }
    }
}
