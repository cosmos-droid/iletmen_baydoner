using System.ComponentModel.DataAnnotations.Schema;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Core;

namespace iletmenbaydoner.Entites.Concrete
{
    [Table("OrderHeaders", Schema = "db_iletmen_baydoner")]
    public class OrderHeader : EntityBaseModel, IEntity
    {
        public long OrderHeaderId { get; set; }
        public long BranchId { get; set; }
        public string OrderNo { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAdress { get; set; }

        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }

    }
}