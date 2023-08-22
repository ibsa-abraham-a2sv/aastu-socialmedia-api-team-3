using Galacticos.Application.Features.Relation.Request.Query;
using Galacticos.Application.Persistence.Contracts;
using MediatR;

namespace Galacticos.Application.Features.Relation.Handlers.Query
{
    public class GetFollowedUsersRequestHandler : IRequestHandler<GetFollowedUsersRequest, List<Guid>>
    {
        private readonly IRelationRepository _relationRepository;

        public GetFollowedUsersRequestHandler(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        public async Task<List<Guid>> Handle(GetFollowedUsersRequest request, CancellationToken cancellationToken)
        {
            var followedUserIds = await _relationRepository.GetFollowedUserIdsByUserId(request.Id);
            return followedUserIds;
        }
    }
}