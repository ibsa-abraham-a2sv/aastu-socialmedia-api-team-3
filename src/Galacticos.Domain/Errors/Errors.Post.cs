using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Galacticos.Domain.Errors
{
    public static partial class Errors
    {
        public static class Post
        {
            public static Error PostNotFound =>
            Error.Failure(code: "PostNotFound", description: "Post not found");
        }
    }
}