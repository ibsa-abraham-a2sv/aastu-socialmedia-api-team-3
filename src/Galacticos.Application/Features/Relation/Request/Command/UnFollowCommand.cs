using Galacticos.Application.DTOs.Relations;
using MediatR;

namespace Galacticos.Application.Features.Relation.Request.Command
{
    public class UnFollowCommand : IRequest<Unit>
    {
        public RelationDTO RelationDTO { get; set; }
    }
}