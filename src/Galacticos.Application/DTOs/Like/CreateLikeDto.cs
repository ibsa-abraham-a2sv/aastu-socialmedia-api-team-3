using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Like
{
    public class CreateLikeDto
    {
        public Guid UserId { get; set; }
        public int PostId { get; set; }
        
    }
}