using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entities.Concrete
{
    [Table("BranchProducts", Schema = "db_iletmen_baydoner")]
    public class BranchProduct : EntityBaseModel, IEntity
    {
        public long BranchProductId { get; set; }
        public long BranchId { get; set; }
        public long ProductGroupTypeId { get; set; }
        public string? ProductName { get; set; }
        public long Price { get; set; }
        public int StockQuantity { get; set; }

        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }

        [ForeignKey("ProductGroupTypeId")]
        public ProductGroupType? ProductGroupType { get; set; }
    }
}