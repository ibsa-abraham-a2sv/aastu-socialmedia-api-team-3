using MediatR;
using Galacticos.Application.DTOs.Relations;
using AutoMapper;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Application.Features.Relation.Request.Query;

namespace Galacticos.Application.Features.Relation.Handler.Query
{
    public class GetFollowersIdRequestHandler : IRequestHandler<GetFollowersIdRequest, List<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;

        public GetFollowersIdRequestHandler(IMapper mapper, IRelationRepository relationRepository)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
        }

        public async Task<List<Guid>> Handle(GetFollowersIdRequest request, CancellationToken cancellationToken)
        {
            var relation = await _relationRepository.GetAllFollowersId(request.id);
            return relation;
        }
    }
}