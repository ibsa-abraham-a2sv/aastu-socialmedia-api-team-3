using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Galacticos.Application.Features.Relation.Request.Query
{
    public class GetFollowersIdRequest : IRequest<List<Guid>>
    {
        public Guid id { get; set; }
    }
}