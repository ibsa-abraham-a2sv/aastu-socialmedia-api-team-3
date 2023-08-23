using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.DTOs.Common;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Application.DTOs.Comments
{
    public class CommentDto : BaseEntityDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; } = null!;   
    }
}