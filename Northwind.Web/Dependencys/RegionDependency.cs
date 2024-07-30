using Northwind.Web.IServices;
using Northwind.Web.Services;


namespace Northwind.Web.Dependencys
{
    public static class RegionDependency
    {
        public static void AddRegionDependency(this IServiceCollection service)
        {
            service.AddHttpClient<IRegionServices, RegionServices>();
        }
    }
}
