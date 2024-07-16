using Northwind.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Regions.Domain.Entities
{
    [Table("Region")]
    public class Region : AuditEntity<int>
    {
        [Column("RegionID")]
        public override int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionDescription { get; set; }
    }
}
