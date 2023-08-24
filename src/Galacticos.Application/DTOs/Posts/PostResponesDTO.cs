using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.DTOs.Comments;
using Galacticos.Application.DTOs.Common;

namespace Galacticos.Application.DTOs.Posts
{
    public class PostResponesDTO : BaseEntityDto
    {
        public string Caption {get; set;} = null!;
        public string Image {get; set;}
        public Guid UserId {get; set;}
        public List<CommentResponesDTO> Comments {get; set;}
        public List<TagDto> Tags {get; set;} = new List<TagDto>();
    }
}