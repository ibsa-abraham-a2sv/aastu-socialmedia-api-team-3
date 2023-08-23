using MediatR;
using Galacticos.Application.DTOs.Relations;

namespace Galacticos.Application.Features.Relation.Request.Query
{
    public class GetFollowedIdsRequest : IRequest<List<Guid>>
    {
        public Guid id { get; set; }
    }
}