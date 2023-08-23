using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.DTOs.Common;

namespace Galacticos.Application.DTOs.Comments
{
    public class CommentResponesDTO : BaseEntityDto
    {
        public string Content {get; set;}
        public Guid PostId {get; set;}
        
    }
}