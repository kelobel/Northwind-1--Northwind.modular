using Microsoft.Extensions.DependencyInjection;
using Northwind.Web.IServices;
using Northwind.Web.Services;


namespace Northwind.Web.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNorthwindDependencies(this IServiceCollection service)
        {
            service.AddHttpClient<IProductsServices, ProductServices>();
            service.AddHttpClient<IShippersServices, ShipperServices>();
            service.AddHttpClient<ISuppliersServices, SupplierServices>();
            service.AddHttpClient<IRegionServices, RegionServices>();
        }
    }
}

