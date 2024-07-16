using Microsoft.EntityFrameworkCore;
using Northwind.Regions.Domain.Interface;
using Northwind.Regions.Domain.Entities;
using Northwind.Regions.Persistence.Context;
using System.Linq.Expressions;

namespace Northwind.Regions.Persistence.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NorthwindContext _context;

        public RegionRepository(NorthwindContext context)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Region, bool>> filter)
        {
            return _context.Regions.Any(filter);
        }

        public List<Region> GetAll()
        {
            return _context.Regions.ToList();
        }

        public Region GetEntityBy(int id)
        {
            return _context.Regions.Find(id);
        }

        public void Remove(Region entity)
        {
            var existingEntity = _context.Regions.Find(entity.Id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("The entity does not exist in the database.");
            }

            try
            {
                _context.Regions.Remove(existingEntity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InvalidOperationException("Concurrency conflict: The entity was modified or deleted by another process.", ex);
            }
        }

        public void Save(Region entity)
        {
            _context.Regions.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Region entity)
        {
            _context.Regions.Update(entity);
            _context.SaveChanges();
        }

        public List<Region> GetRegions()
        {
            return _context.Regions.ToList();
        }
    }
}
