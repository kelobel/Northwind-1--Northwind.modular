using Northwind.Web.Results.Region_Results;
using Northwind.Web.Models.RegionModels;
using Northwind.Web.Results;
namespace Northwind.Web.IServices
{
    public interface IRegionServices
    {
        Task<RegionGetListResult> GetRegionAsync();
        Task<RegionGetResult> GetRegionByIdAsync(int id);
        Task<BaseResult> CreateRegionAsync(RegionGetModel region);
        Task<BaseResult> UpdateRegionAsync(int id, RegionGetModel region);
        Task<BaseResult> DeleteRegionAsync(int id);
    }
}
