using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entities.Concrete
{
    [Table("ProductGroupTypes", Schema = "db_iletmen_baydoner")]
    public class ProductGroupType : EntityBaseModel, IEntity
    {
        public long ProductGroupTypeId { get; set; }
        public long ProductGroupId { get; set; }
        public string? ProductGroupTypeName { get; set; }
        public string? Code { get; set; }
        [ForeignKey("ProductGroupId")]
        public ProductGroup? ProductGroup { get; set; }
    }
}