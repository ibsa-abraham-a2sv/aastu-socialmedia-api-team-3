using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Galacticos.Infrastructure.Data;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Infrastructure.Persistence.Repositories.UserRepo;
using Galacticos.Persistence.Repositories;
using Galacticos.Infrastructure.Persistence.Repositories;
using Galacticos.Infrastructure.Persistence.Repositories.RelationRepo;
using Galacticos.Infrastructure.Persistence.Repositories.PostRepo;

namespace Galacticos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDbContext>(opt =>
    opt.UseNpgsql(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<INewsFeedRepository, NewsFeedRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRelationRepository, RelationRepository>();
            return services;
        }
    }
}