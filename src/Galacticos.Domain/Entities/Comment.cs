using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class Comment : BaseEntity
    {

        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; } = null!;
<<<<<<< HEAD

        public virtual Post Post { get; set; }
=======
<<<<<<< HEAD

        public virtual Post Post { get; set; }
=======
        public Post Post { get; set; }

        public Comment()
        {
            Post = new Post();
        }
>>>>>>> 98bd29f4e2eb41dc0b15876d856ac449b2630664
>>>>>>> main
    }
}