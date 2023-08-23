using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.DTOs.Posts
{
    public class GetPostDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Caption { get; set; } = null!;
        public string Image { get; set; } = "";
    }
}