using Northwind.Web.Models;
using Northwind.Web.Results;

namespace Northwind.Web.Result.ProductResult
{
    public class ProductGetListResult: BaseResult
    {
        public List<ProductBaseModel> result { get; set; }
    }
}
