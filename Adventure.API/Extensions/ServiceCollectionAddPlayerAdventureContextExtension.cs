using Adventure.Infrastructure.AdventureContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.API.Extensions
{
    public static class ServiceCollectionAddPlayerAdventureContextExtension
    {
        public static IServiceCollection AddPlayerAdventureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlayerAdventureContext>(options =>
            options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(PlayerAdventureContext).Assembly.FullName)));

            return services;
        }
    }
}
