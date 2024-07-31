using Northwind.Web.Models;
using Northwind.Web.Results;
namespace Northwind.Web.Result.SuppliersResult
{
    public class SuppliersGetListResult : BaseResult
    {
        public List<SuppliersBaseModel> result { get; set; }
    }
}
