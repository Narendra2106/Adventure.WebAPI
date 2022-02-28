using Adventure.Domain.AggregatesModel;
using Adventure.Domain.AggregatesModel.Adventure;
using Adventure.Domain.AggregatesModel.AdventureType;
using Adventure.Infrastructure.Repository;
using Adventure.Infrastructure.RepositoryBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.API.Extensions
{
    public static class ServiceCollectionCustomScopedExtensions
    {
        public static IServiceCollection AddCustomScoped(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IAdventureService, AdventureService>();
            services.AddScoped<IAdventureTypeService, AdventureTypeService>();


            // Repositories 
            services.AddScoped<IAdventureRepository, AdventureRepository>();
            services.AddScoped<IAdventureTypeRepository, AdventureTypeRepository>();

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
