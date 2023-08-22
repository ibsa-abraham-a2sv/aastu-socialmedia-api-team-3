using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Likes
{
    public class CreateLikeDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        
    }
}