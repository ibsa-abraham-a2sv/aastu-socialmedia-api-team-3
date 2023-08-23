using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Posts
{
    public class CreatePostRequestDTO
    {
        public string Caption { get; set; } = null!;
        public string Image { get; set; } = "";
        public List<string> Tags { get; set; } = new List<string>();
    }
}