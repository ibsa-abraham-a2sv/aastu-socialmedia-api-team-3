using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public int UserId;
        public string Content;
    }
}