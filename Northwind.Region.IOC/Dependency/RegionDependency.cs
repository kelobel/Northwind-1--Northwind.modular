using Microsoft.Extensions.DependencyInjection;
using Northwind.Regions.Application.Contracts;
using Northwind.Regions.Application.Services;
using Northwind.Regions.Domain.Interface;
using Northwind.Regions.Persistence.Repository;

namespace Northwind.Region.IOC.Dependency
{
    public static class RegionDependency
    {
        public static void AddRegionDependency(this IServiceCollection services)
        {
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRegionService, RegionService>();
        }
    }
}
