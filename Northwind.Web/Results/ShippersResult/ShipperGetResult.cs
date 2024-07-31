using Northwind.Web.Models;
using Northwind.Web.Results;
namespace Northwind.Web.Result.ShippersResult
{
    public class ShipperGetResult:  BaseResult
    {
        public ShippersBaseModel result { get; set; }
    }
}
