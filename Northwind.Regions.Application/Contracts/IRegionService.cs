using Northwind.Regions.Application.Base;
using Northwind.Regions.Application.Dtos;

namespace Northwind.Regions.Application.Contracts
{
    public interface IRegionService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Add(RegionDtoSave region);
        ServiceResult Update(RegionDtoUpdate region);
        ServiceResult Remove(RegionDtoRemove region);
    }
}
