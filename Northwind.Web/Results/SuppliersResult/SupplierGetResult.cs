using Northwind.Web.Models;
using Northwind.Web.Results;
namespace Northwind.Web.Result.SuppliersResult
{
    public class SupplierGetResult: BaseResult
    {
        public SuppliersBaseModel result { get; set; }
    }
}
