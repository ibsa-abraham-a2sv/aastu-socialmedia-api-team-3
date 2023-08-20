using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Galacticos.Domain.Entities;
namespace Galacticos.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(p => p.Posts)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasMany(c => c.Comments)
                    .WithOne(p => p.Post)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasMany(l => l.Likes)
                    .WithOne(p => p.Post)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(f => f.Followers)
                    .WithOne(u => u.FollowedUser)
                    .HasForeignKey(u => u.FollowedUserId);
            });
        }
        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Like> likes { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Follow> relations { get; set; }
        public DbSet<Notification> notifications { get; set; }
    }
}