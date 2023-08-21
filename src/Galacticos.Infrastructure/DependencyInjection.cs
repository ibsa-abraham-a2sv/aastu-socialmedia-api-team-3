using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Galacticos.Infrastructure.Data;
using Galacticos.Application.Persistence.Contracts;
using Galacticos.Infrastructure.Persistence;

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
            return services;
        }
    }
}