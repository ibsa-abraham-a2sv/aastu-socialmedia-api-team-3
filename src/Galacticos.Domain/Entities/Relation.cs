using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Domain.Entities
{
    public class Relation
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
    }
}