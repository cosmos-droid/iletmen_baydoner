namespace iletmenbaydoner.Entities.Concrete
{
    using System.ComponentModel.DataAnnotations.Schema;
    using iletmenbaydoner.Entities.Core;

    [Table("ProductGroups", Schema = "db_iletmen_baydoner")]
    public class ProductGroup : EntityBaseModel, IEntity
    {
        public long ProductGroupId { get; set; }
        public string? ProductGroupName { get; set; }
        public string? Code { get; set; }

    }
}