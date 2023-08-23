using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Posts
{
    public class UpdatePostRequestDTO
    {
        public string? Caption {get; set;} = "";
        public string? Image {get; set;}= "";
    }
}