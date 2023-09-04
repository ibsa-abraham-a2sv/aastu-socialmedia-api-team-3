using MediatR;
using Galacticos.Application.DTOs.Relations;
using AutoMapper;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Features.Relation.Request.Query;

namespace Galacticos.Application.Features.Relation.Handler.Query
{
    public class GetRelationRequestHandler : IRequestHandler<GetRelationRequest, GetFollowersDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;

        public GetRelationRequestHandler(IMapper mapper, IRelationRepository relationRepository)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
        }

        public async Task<GetFollowersDTO> Handle(GetRelationRequest request, CancellationToken cancellationToken)
        {
            var relation = await _relationRepository.Get(request.RelationDTO.FollowerId, request.RelationDTO.FollowedUserId);
            return _mapper.Map<GetFollowersDTO>(relation);
        }
    }
}