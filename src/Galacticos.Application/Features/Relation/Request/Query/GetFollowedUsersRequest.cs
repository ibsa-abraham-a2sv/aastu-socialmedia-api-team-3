using MediatR;

namespace Galacticos.Application.Features.Relation.Request.Query
{
    public class GetFollowedUsersRequest : IRequest<List<Guid>>
    {
        public Guid Id { get; set; }
    }
}