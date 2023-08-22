using MediatR;
using Galacticos.Application.DTOs.Relations;
using AutoMapper;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Features.Relation.Request.Query;

namespace Galacticos.Application.Features.Relation.Handler.Query
{
    public class GetFollowedIdsRequestHandler : IRequestHandler<GetFollowedIdsRequest, List<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;

        public GetFollowedIdsRequestHandler(IMapper mapper, IRelationRepository relationRepository)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
        }

        public async Task<List<Guid>> Handle(GetFollowedIdsRequest request, CancellationToken cancellationToken)
        {
            var relation = await _relationRepository.GetAllFollowedIdsByUserId(request.id);
            return relation;
        }
    }
}