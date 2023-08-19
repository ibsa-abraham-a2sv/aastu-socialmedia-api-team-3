using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; } = false;
        public User user { get; set; } = null!;
    }
}   