using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Like : BaseEntity
    {
        public int UserId;
        public int PostId;
    }
}