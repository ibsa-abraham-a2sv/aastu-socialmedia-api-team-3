using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class Follow : BaseEntity
    {
        // public Follow()
        // {
        //     Follower = new User();
        //     FollowedUser = new User();
        // }
        public int FollowerId { get; set; }
        public User Follower { get; set; } // Navigation property
        
        public int FollowedUserId { get; set; }
        public User FollowedUser { get; set; } // Navigation property
    }
}