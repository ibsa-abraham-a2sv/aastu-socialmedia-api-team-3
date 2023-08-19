using Galacticos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galacticos.Infrastructure.Data
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {}
        
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}