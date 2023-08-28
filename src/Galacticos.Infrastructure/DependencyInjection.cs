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
using Galacticos.Infrastructure.Repositories.RelationRepo;
using Galacticos.Infrastructure.Persistence.Repositories.PostRepo;
using Galacticos.Application.Common.Interface.Authentication;
using Galacticos.Infrastructure.Authentication;
using Galacticos.Application.Common.Interface.Services;
using Galacticos.Infrastructure.Services;
using Galacticos.Infrastructure.Persistence.Repositories.CommentRepo;
using Galacticos.Infrastructure.Persistence.Repositories.PostTagRepo;
using Galacticos.Application.Services.Authentication;

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
            services.AddScoped<INewsFeedRepository, NewsFeedRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRelationRepository, RelationRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostTagRepository, PostTagRepository>();
            services.AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IPasswordHashService, PasswordHashService>();

            return services;
        }
    }
}