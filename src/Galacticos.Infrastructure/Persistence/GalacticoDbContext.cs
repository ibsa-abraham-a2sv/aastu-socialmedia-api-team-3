using Galacticos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galacticos.Infrastructure.Persistence
{
    public class GalacticoDbContext : DbContext
    {
        public GalacticoDbContext(DbContextOptions<GalacticoDbContext> options) : base(options)
        {
            
        }

        public DbSet<Post> posts { get; set; }
    }
}
