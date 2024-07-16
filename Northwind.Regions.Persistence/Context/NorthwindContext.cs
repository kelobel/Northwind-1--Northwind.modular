using Microsoft.EntityFrameworkCore;
using Northwind.Regions.Domain.Entities;


namespace Northwind.Regions.Persistence.Context
{
    public class NorthwindContext : DbContext
    {
        #region "Constructor"

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Region> Regions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("RegionID");
                entity.Property(e => e.RegionDescription).HasColumnName("RegionDescription").HasMaxLength(50).IsRequired();
            });
        }
    }
}
