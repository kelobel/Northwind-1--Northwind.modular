using Northwind.Regions.Domain.Entities;
using System.Linq.Expressions;

namespace Northwind.Regions.Domain.Interface
{
    public interface IRegionRepository
    {
        List<Region> GetRegions();
        bool Exists(Expression<Func<Region, bool>> filter);
        List<Region> GetAll();
        Region GetEntityBy(int id);
        void Remove(Region entity);
        void Save(Region entity);
        void Update(Region entity);
    }
}
