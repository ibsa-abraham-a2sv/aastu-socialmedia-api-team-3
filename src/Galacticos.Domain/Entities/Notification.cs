using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public Guid UserById { get; set; }
        public Guid UserToId { get; set; }
        public int Content { get; set; }
        public bool IsRead { get; set; } = false;
        public User user { get; set; } = null!;
    }
}