using Northwind.Web.Models;
using Northwind.Web.Results;
namespace Northwind.Web.Result.ShippersResult
{
    public class ShippersGetListResult: BaseResult
    {
        public List<ShippersBaseModel> result { get; set; }
    }
}
