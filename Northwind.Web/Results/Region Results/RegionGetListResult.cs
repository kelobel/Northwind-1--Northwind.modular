using Northwind.Web.Models.RegionModels;

namespace Northwind.Web.Results.Region_Results
{
    public class RegionGetListResult : BaseResult
    {
        public List<RegionGetModel> result { get; set; }
    }
}
