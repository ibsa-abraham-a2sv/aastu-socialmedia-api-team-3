using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity
    {
        public int Id;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}