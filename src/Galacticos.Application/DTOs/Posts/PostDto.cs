using Galacticos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Posts
{
    public class PostDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Caption { get; set; } = null!;
        public string Image { get; set; } = "";

        public virtual ICollection<Comment>? comments { get; set; }
        public virtual User? user { get; set; }
    }
}