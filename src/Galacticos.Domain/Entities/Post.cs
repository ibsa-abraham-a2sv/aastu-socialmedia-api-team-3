using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }
        public Guid UserId { get; set; }
        public string Caption { get; set; } = null!;
        public string Image { get; set; } = "";
<<<<<<< HEAD

        public virtual ICollection<Comment> comments { get; set; }
        public virtual User user { get; set; }

=======
        public User user { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
>>>>>>> 98bd29f4e2eb41dc0b15876d856ac449b2630664
    }
}