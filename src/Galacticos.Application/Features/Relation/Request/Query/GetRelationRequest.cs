using MediatR;
using Galacticos.Application.DTOs.Relations;

namespace Galacticos.Application.Features.Relation.Request.Query
{
    public class GetRelationRequest : IRequest<RelationDTO>
    {
        public RelationDTO RelationDTO { get; set; }
    }
}